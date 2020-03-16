using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.OnHitEffects;
using Assets.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDamageOnHitEffect : OnHitEffect
{
    public enum DamageType
    {
        SpellDamage,
        PhysicalDamage,
    }

    public DamageType damageType = DamageType.PhysicalDamage;

    public float baseDamage = 0f;
    public float damagePerAttackPoint = 1f;

    private static readonly IReadOnlyDictionary<DamageType, (StatsController.StatType statType, Func<float, Damage> constructor)> damageMap 
        = new Dictionary<DamageType, (StatsController.StatType statType, Func<float, Damage> constructor)>()
        {
            { 
                DamageType.PhysicalDamage,
                (StatsController.StatType.AttackPower, (x) => new PhysicalDamage(x))
            },
            {
                DamageType.SpellDamage,
                (StatsController.StatType.SpellPower, (x) => new SpellDamage(x))
            } 
        };

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Vector3 position, Vector3 normal, Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
    {
        StatsController srcStats = weapon.owner.actor.statsController;

        DoDamage(target, result, srcStats, damageType);

        return result;
    }

    private void DoDamage(IWeaponTarget target, ApplyOnHitEffectsResult result, StatsController srcStats, DamageType damageType)
    {
        if(damageMap.ContainsKey(damageType))
        {
            (var statType, var constructor) = damageMap[damageType];
            float amount = srcStats.GetStat(statType).CalculateStatValue() * damagePerAttackPoint + baseDamage;
            target.DoDamage(constructor?.Invoke(amount));
            result.applyEffects = true;
        }
    }
}