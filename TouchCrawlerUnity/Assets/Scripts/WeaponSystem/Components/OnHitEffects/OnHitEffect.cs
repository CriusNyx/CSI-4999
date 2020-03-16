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

        public override ApplyOnHitEffectsResult ApplyOnHitEffects(Vector3 position, Vector3 normal, Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result) {
            if (ApplyDebuff(target))
            {
                SpawnAnimation(target.gameObject.transform.position);
                ApplyKnockback(weapon, target);
                result.applyEffects = true;
            }
            return result;
        }

        private bool ApplyDebuff(IWeaponTarget target) {
            //TODO: Debuffs
            //Get Target Actor
            //Apply debuff to target
            //Return based on success of applying debuff
            //throw new System.NotImplementedException();
            return false;
        }
    }
}