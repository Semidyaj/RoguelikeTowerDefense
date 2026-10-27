using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Tests.Fakes;

namespace RoguelikeTD.Tests.Core.ConfigsManagement
{
    public class ConfigsProviderServiceTests
    {
        [Test]
        public async Task GetConfig_AfterLoadFromSeveralLoaders_ReturnsConfigsFromEach()
        {
            FirstConfig first = new FirstConfig();
            SecondConfig second = new SecondConfig();
            ConfigsProviderService service = new ConfigsProviderService(
                new FakeConfigsLoader(first),
                new FakeConfigsLoader(second));

            await service.LoadAsync();

            Assert.AreSame(first, service.GetConfig<FirstConfig>());
            Assert.AreSame(second, service.GetConfig<SecondConfig>());
        }

        [Test]
        public void GetConfig_NotLoaded_ThrowsInvalidOperationException()
        {
            ConfigsProviderService service = new ConfigsProviderService(new FakeConfigsLoader(new FirstConfig()));

            Assert.Throws<InvalidOperationException>(() => service.GetConfig<FirstConfig>());
        }

        [Test]
        public async Task LoadAsync_CalledTwice_KeepsConfigs()
        {
            FirstConfig first = new FirstConfig();
            ConfigsProviderService service = new ConfigsProviderService(new FakeConfigsLoader(first));
            await service.LoadAsync();

            await service.LoadAsync();

            Assert.AreSame(first, service.GetConfig<FirstConfig>());
        }

        private class FirstConfig { }

        private class SecondConfig { }
    }
}
