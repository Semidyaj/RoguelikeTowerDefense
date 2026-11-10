using System;
using NUnit.Framework;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using UnityEngine;

namespace RoguelikeTD.Tests.Gameplay.Features.PauseFeature
{
    public class TimeScalePauseServiceTests
    {
        [TearDown]
        public void TearDown()
        {
            Time.timeScale = 1;
        }

        [Test]
        public void Pause_StopsTime()
        {
            TimeScalePauseService service = new();

            service.Pause();

            Assert.IsTrue(service.IsPaused);
            Assert.AreEqual(0f, Time.timeScale);
        }

        [Test]
        public void Unpause_AfterSinglePause_ResumesTime()
        {
            TimeScalePauseService service = new();
            service.Pause();

            service.Unpause();

            Assert.IsFalse(service.IsPaused);
            Assert.AreEqual(1f, Time.timeScale);
        }

        [Test]
        public void Unpause_WithNestedPause_KeepsTimeStopped()
        {
            TimeScalePauseService service = new();
            service.Pause();
            service.Pause();

            service.Unpause();

            Assert.IsTrue(service.IsPaused);
            Assert.AreEqual(0f, Time.timeScale);
        }

        [Test]
        public void Unpause_LastOfNestedPauses_ResumesTime()
        {
            TimeScalePauseService service = new();
            service.Pause();
            service.Pause();

            service.Unpause();
            service.Unpause();

            Assert.IsFalse(service.IsPaused);
            Assert.AreEqual(1f, Time.timeScale);
        }

        [Test]
        public void Unpause_WithoutPause_Throws()
        {
            TimeScalePauseService service = new();

            Assert.Throws<InvalidOperationException>(() => service.Unpause());
        }

        [Test]
        public void Dispose_WhilePaused_ResumesTime()
        {
            TimeScalePauseService service = new();
            service.Pause();
            service.Pause();

            service.Dispose();

            Assert.IsFalse(service.IsPaused);
            Assert.AreEqual(1f, Time.timeScale);
        }
    }
}
