using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE
{
    public readonly struct AOEInfoStruct
    {
        public readonly float Damage;
        public readonly float Radius;
        public readonly Vector3 Position;
        public readonly LayerMask DamageMask;

        public AOEInfoStruct(float damage, float radius, Vector3 position, LayerMask damageMask)
        {
            Damage = damage;
            Radius = radius;
            Position = position;
            DamageMask = damageMask;
        }
    }
}
