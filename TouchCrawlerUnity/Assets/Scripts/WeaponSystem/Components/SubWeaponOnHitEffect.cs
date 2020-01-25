using Assets.WeaponSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Util.DecoratorUtil;

namespace Assets.Scripts.WeaponSystem.Components
{
    class SubWeaponOnHitEffect : WeaponComponent
    {
        public HybridWeapon parent;

        public override ComponentType componentType => ComponentType.OnHitEffect;

        public override ApplyOnHitEffectsResult ApplyOnHitEffects(Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
        {
            var components = parent.GetComponents<WeaponComponent>();

            result = PropegateMonad(
                result,
                components,
                (x, y) => x.ApplyOnHitEffects(weapon, target, y));

            return result;
        }
    }
}
