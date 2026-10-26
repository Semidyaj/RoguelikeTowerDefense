using System.Collections.Generic;
using NUnit.Framework;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.LevelsProgression;

namespace RoguelikeTD.Tests.Meta.Features.LevelsProgression
{
    public class LevelsProgressionServiceTests
    {
        [Test]
        public void CanPlay_FirstLevel_ReturnsTrue()
        {
            LevelsProgressionService service = CreateService();

            Assert.IsTrue(service.CanPlay(1));
        }

        [Test]
        public void CanPlay_WhenPreviousNotCompleted_ReturnsFalse()
        {
            LevelsProgressionService service = CreateService();

            Assert.IsFalse(service.CanPlay(2));
        }

        [Test]
        public void CanPlay_WhenPreviousCompleted_ReturnsTrue()
        {
            LevelsProgressionService service = CreateService();
            service.AddLevelToCompleted(1);

            Assert.IsTrue(service.CanPlay(2));
        }

        [Test]
        public void AddLevelToCompleted_MarksLevelCompleted()
        {
            LevelsProgressionService service = CreateService();

            service.AddLevelToCompleted(1);

            Assert.IsTrue(service.IsLevelCompleted(1));
        }

        [Test]
        public void AddLevelToCompleted_Twice_StoresOnce()
        {
            LevelsProgressionService service = CreateService();

            service.AddLevelToCompleted(1);
            service.AddLevelToCompleted(1);

            CollectionAssert.AreEqual(new[] { 1 }, service.CompletedLevels);
        }

        [Test]
        public void ReadFrom_ReplacesPreviousProgress()
        {
            LevelsProgressionService service = CreateService();
            service.AddLevelToCompleted(1);
            PlayerData data = new PlayerData { CompletedLevels = new List<int> { 1, 2 } };

            service.ReadFrom(data);

            CollectionAssert.AreEqual(new[] { 1, 2 }, service.CompletedLevels);
        }

        [Test]
        public void WriteTo_ThenReadFrom_RestoresProgress()
        {
            LevelsProgressionService savedService = CreateService();
            savedService.AddLevelToCompleted(1);
            savedService.AddLevelToCompleted(2);
            PlayerData data = new PlayerData();
            savedService.WriteTo(data);
            LevelsProgressionService loadedService = CreateService();

            loadedService.ReadFrom(data);

            CollectionAssert.AreEqual(new[] { 1, 2 }, loadedService.CompletedLevels);
            Assert.IsTrue(loadedService.CanPlay(3));
        }

        private static LevelsProgressionService CreateService()
            => new LevelsProgressionService(new PlayerDataProvider(null, null));
    }
}
