using NUnit.Framework;
using RoguelikeTD.Gameplay.Features.Attack.Shoot;
using UnityEngine;

namespace RoguelikeTD.Tests.Gameplay.Features.Attack.Shoot
{
    public class InterceptCalculatorTests
    {
        private const float Tolerance = 0.001f;
        private const float ProjectileSpeed = 20f;

        [Test]
        public void TryGetInterceptPoint_StandingTarget_ReturnsTargetPosition()
        {
            Vector3 target = new Vector3(10, 0, 0);

            bool found = InterceptCalculator.TryGetInterceptPoint(Vector3.zero, target, Vector3.zero, ProjectileSpeed, out Vector3 point);

            Assert.IsTrue(found);
            Assert.AreEqual(0f, Vector3.Distance(target, point), Tolerance);
        }

        [Test]
        public void TryGetInterceptPoint_CrossingTarget_ProjectileAndTargetArriveTogether()
        {
            Vector3 target = new Vector3(10, 0, 0);
            Vector3 targetVelocity = new Vector3(0, 0, 5);

            bool found = InterceptCalculator.TryGetInterceptPoint(Vector3.zero, target, targetVelocity, ProjectileSpeed, out Vector3 point);

            float targetTime = Vector3.Distance(target, point) / targetVelocity.magnitude;
            float projectileTime = point.magnitude / ProjectileSpeed;

            Assert.IsTrue(found);
            Assert.Greater(point.z, 0f);
            Assert.AreEqual(targetTime, projectileTime, Tolerance);
        }

        [Test]
        public void TryGetInterceptPoint_TargetFasterAndRunningAway_ReturnsFalse()
        {
            Vector3 target = new Vector3(10, 0, 0);
            Vector3 targetVelocity = new Vector3(30, 0, 0);

            bool found = InterceptCalculator.TryGetInterceptPoint(Vector3.zero, target, targetVelocity, ProjectileSpeed, out _);

            Assert.IsFalse(found);
        }
    }
}
