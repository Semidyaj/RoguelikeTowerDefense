using NUnit.Framework;
using RoguelikeTD.Gameplay.Features.Attack.Shoot;

namespace RoguelikeTD.Tests.Gameplay.Features.Attack.Shoot
{
    public class InstantShootingDirectionArgsTests
    {
        [Test]
        public void Add_SameAngle_SumsProjectileCounts()
        {
            InstantShootingDirectionArgs args = new InstantShootingDirectionArgs(new InstantShotDirectionArgs(0, 1));

            args.Add(new InstantShotDirectionArgs(0, 2));

            Assert.AreEqual(1, args.Args.Count);
            Assert.AreEqual(3, args.Args[0].ProjectileCounts);
        }

        [Test]
        public void Remove_PartOfProjectiles_KeepsDirection()
        {
            InstantShootingDirectionArgs args = new InstantShootingDirectionArgs(new InstantShotDirectionArgs(45, 3));

            args.Remove(new InstantShotDirectionArgs(45, 1));

            Assert.AreEqual(1, args.Args.Count);
            Assert.AreEqual(2, args.Args[0].ProjectileCounts);
        }

        [Test]
        public void Remove_AllProjectilesOfAngle_RemovesDirection()
        {
            InstantShootingDirectionArgs args = new InstantShootingDirectionArgs(new InstantShotDirectionArgs(0, 1));
            args.Add(new InstantShotDirectionArgs(45, 2));

            args.Remove(new InstantShotDirectionArgs(45, 2));

            Assert.AreEqual(1, args.Args.Count);
            Assert.AreEqual(0, args.Args[0].Angle);
        }
    }
}
