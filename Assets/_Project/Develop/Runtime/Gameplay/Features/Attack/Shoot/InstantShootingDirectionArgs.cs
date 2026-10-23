using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Shoot
{
    public class InstantShootingDirectionArgs
    {
        private List<InstantShotDirectionArgs> _args;

        public InstantShootingDirectionArgs(params InstantShotDirectionArgs[] args)
        {
            _args = new List<InstantShotDirectionArgs>(args);
        }

        public IReadOnlyList<InstantShotDirectionArgs> Args => _args;

        public void Add(InstantShotDirectionArgs instantShotDirectionArgs)
        {
            var arg = _args.FirstOrDefault(ar => ar.Angle == instantShotDirectionArgs.Angle);

            if(arg != null)
            {
                arg.ProjectileCounts += instantShotDirectionArgs.ProjectileCounts;
                return;
            }

            _args.Add(instantShotDirectionArgs);
        }

        public void Remove(InstantShotDirectionArgs instantShotDirectionArgs)
        {
            var arg = _args.FirstOrDefault(ar => ar.Angle == instantShotDirectionArgs.Angle);

            if(arg != null)
            {
                arg.ProjectileCounts -= instantShotDirectionArgs.ProjectileCounts;

                if (arg.ProjectileCounts <= 0)
                    _args.Remove(instantShotDirectionArgs);
            }
        }
    }
}
