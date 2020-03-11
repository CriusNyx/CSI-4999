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
        StatsController srcStats = weapon.owner.actor.StatsController;

        if (weapon.damage.Equals(typeof(SpellDamage))){
            SpellDamage damage = weapon.damage;
            damage += srcStats.GetStat(SpellPower).CalculateStatValue * 0.1f;
        } else if (weapon.damage.Equals(typeof(PhysicalDamage))) {
            PhysicalDamage damage = weapon.damage;
            damage += srcStats.GetStat(AttackPower).CalculateStatValue * 0.1f;
        } else {
            Damage damage = weapon.damage;
        }
        result.applyEffects = true;
        target.DoDamage(damage);
        return result;
    }
}