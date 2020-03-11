using Assets.Scripts.Util.Latches;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components.OnHitEffects {
    public abstract class OnHitEffect : WeaponComponent
    {
        public override ComponentType componentType => ComponentType.OnHitEffect;

        public MasterLatch latch = new MasterLatch();

        public override ApplyOnHitEffectsResult ApplyOnHitEffects(Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result) {
            if (ApplyDebuff(target))
            {
                SpawnAnimation(target.gameObject.transform.position);
                ApplyKnockback(weapon, target);
                result.applyEffects = true;
            }
            return result;
        } 

    }
}