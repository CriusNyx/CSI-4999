using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.OnHitEffects;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDamageOnHitEffect : OnHitEffect
{

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
    {
        StatsController srcStats = weapon.owner.actor.statsController;

        if (weapon.Damage.Equals(typeof(SpellDamage))){
            SpellDamage damage = (SpellDamage)weapon.Damage;
            damage.amount += srcStats.GetStat(StatsController.StatType.SpellPower).CalculateStatValue() * 0.1f;
            target.DoDamage(damage);
        } else if (weapon.Damage.Equals(typeof(PhysicalDamage))) {
            PhysicalDamage damage = (PhysicalDamage)weapon.Damage;
            damage.amount += srcStats.GetStat(StatsController.StatType.AttackPower).CalculateStatValue() * 0.1f;
            target.DoDamage(damage);
        } else {
            Damage damage = weapon.Damage;
            target.DoDamage(damage);
        }
        result.applyEffects = true;
        
        return result;
    }
}