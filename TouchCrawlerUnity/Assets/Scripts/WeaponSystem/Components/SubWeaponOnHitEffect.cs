using Assets.WeaponSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Util.DecoratorUtil;

namespace Assets.Scripts.WeaponSystem.Components
{
    class SubWeaponOnHitEffect : WeaponComponent
    {
        public HybridWeapon parent;

        public override ComponentType componentType => ComponentType.OnHitEffect;

        public override ApplyOnHitEffectsResult ApplyOnHitEffects(Vector3 position, Vector3 normal, Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
        {
            var components = parent.GetComponents<WeaponComponent>();

            result = PropegateMonad(
                result,
                components,
                (x, y) => x.ApplyOnHitEffects(position, normal, weapon, target, y));

            return result;
        }
    }
}
