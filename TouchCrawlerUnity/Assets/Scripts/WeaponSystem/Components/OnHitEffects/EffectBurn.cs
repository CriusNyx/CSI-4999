using Assets.Scripts.Util.Latches;
using Assets.Scripts.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.WeaponSystem.Components.OnHitEffects;


namespace Assets.Scripts.WeaponSystem.Components.OnHitEffects {
    public class EffectBurn : OnHitEffect, MonoBehavior
    { 
        /* Apply Fire typed DoT to target
        ** Damage is based on stats/level
        ** while legth is static
        */

        float coefficient = 0.1f;
        int burnTime = 6;

        int SecondsPerTick = 2;

        float amount = 0f;

        IWeaponTarget target = null;

        public override ApplyOnHitEffectsResult ApplyOnHitEffects(Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result) {

            StatsController srcStats = weapon.owner.actor.statsController;
            this.target = target;

            stat spellPower = srcStats.GetStat(StatType.SpellPower);

            this.amount = spellPower.BaseValue;
            this.amount += spellPower.CalculateStatValue * coefficient;

            StartCoroutine(BurnTarget);

            result.applyEffects = true;

            return result;
        }
        IEnumerator BurnTarget() {

            for (int i = 0; i < (burnTime/SecondsPerTick); i++){

                //TODO: Spawn Fire on targets location

                yield return new waitforseconds(SecondsPerTick);
                SpellDamage damage = new SpellDamage(amount/(burnTime/SecondsPerTick));
                target.DoDamage(damage);
            }
        }
    }


}