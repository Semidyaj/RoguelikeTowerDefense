using Newtonsoft.Json;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Infrastructure.Launch;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.Meta.Features.StatsUpgrade;
using RoguelikeTD.Meta.Features.Wallet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;

namespace RoguelikeTD.Infrastructure.PlaythroughTracking
{
    public class PlaythroughTracker : IDisposable
    {
        private const string FolderName = "Telemetry";

        private readonly LaunchSettings _launchSettings;
        private readonly WalletService _walletService;
        private readonly StatsUpgradeService _statsUpgradeService;
        private readonly BoostAbilitiesShopService _boostAbilitiesShopService;
        private readonly LevelsProgressionService _levelsProgressionService;

        private readonly List<IDisposable> _subscriptions = new();

        private readonly Stopwatch _sessionTime = new();

        private string _filePath;

        public PlaythroughTracker(
            LaunchSettings launchSettings,
            WalletService walletService,
            StatsUpgradeService statsUpgradeService,
            BoostAbilitiesShopService boostAbilitiesShopService,
            LevelsProgressionService levelsProgressionService)
        {
            _launchSettings = launchSettings;
            _walletService = walletService;
            _statsUpgradeService = statsUpgradeService;
            _boostAbilitiesShopService = boostAbilitiesShopService;
            _levelsProgressionService = levelsProgressionService;
        }

        public bool IsActive => _filePath != null;

        public void StartSession()
        {
            if (_launchSettings.TrackPlaythrough == false || IsActive)
                return;

            string folder = Path.Combine(Path.GetDirectoryName(Application.dataPath), _launchSettings.EditorSavesFolder, FolderName);
            Directory.CreateDirectory(folder);

            _filePath = Path.Combine(folder, $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.jsonl");
            _sessionTime.Start();

            foreach (StatTypes statType in _statsUpgradeService.AvailableStats)
                _subscriptions.Add(_statsUpgradeService.GetStatLevelFor(statType).Subscribe((oldLevel, newLevel) => OnStatUpgraded(statType, newLevel)));

            _boostAbilitiesShopService.OnBoostsChanged += OnBoostsChanged;

            Write("session_start", new Dictionary<string, object>
            {
                ["wallet"] = GetWallet(),
                ["statLevels"] = GetStatLevels(),
                ["completedLevels"] = _levelsProgressionService.CompletedLevels.ToList(),
                ["boosts"] = GetBoosts(),
            });
        }

        public Dictionary<string, int> GetWallet()
            => _walletService.AvailableCurrencies.ToDictionary(currency => currency.ToString(), currency => _walletService.GetCurrency(currency).Value);

        public List<string> GetBoosts() => _boostAbilitiesShopService.PurcasedBoostAbilities.Keys.ToList();

        public void Write(string eventType, Dictionary<string, object> data)
        {
            if (IsActive == false)
                return;

            Dictionary<string, object> line = new()
            {
                ["t"] = Math.Round(_sessionTime.Elapsed.TotalSeconds, 2),
                ["event"] = eventType,
            };

            foreach (KeyValuePair<string, object> pair in data)
                line[pair.Key] = pair.Value;

            File.AppendAllText(_filePath, JsonConvert.SerializeObject(line) + "\n");
        }

        public void Dispose()
        {
            if (IsActive == false)
                return;

            Write("session_end", new Dictionary<string, object> { ["wallet"] = GetWallet() });

            foreach (IDisposable subscription in _subscriptions)
                subscription.Dispose();

            _subscriptions.Clear();
            _boostAbilitiesShopService.OnBoostsChanged -= OnBoostsChanged;
            _filePath = null;
        }

        private Dictionary<string, int> GetStatLevels()
            => _statsUpgradeService.AvailableStats.ToDictionary(stat => stat.ToString(), stat => _statsUpgradeService.GetStatLevelFor(stat).Value);

        private void OnStatUpgraded(StatTypes statType, int newLevel)
            => Write("stat_upgraded", new Dictionary<string, object>
            {
                ["stat"] = statType.ToString(),
                ["level"] = newLevel,
                ["value"] = _statsUpgradeService.GetCurrentStatValueFor(statType),
                ["wallet"] = GetWallet(),
            });

        private void OnBoostsChanged()
            => Write("boosts_changed", new Dictionary<string, object>
            {
                ["boosts"] = GetBoosts(),
                ["wallet"] = GetWallet(),
            });
    }
}
