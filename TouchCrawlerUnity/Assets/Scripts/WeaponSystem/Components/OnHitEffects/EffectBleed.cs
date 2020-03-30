using Assets.Scripts.Util.Latches;
using Assets.Scripts.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.WeaponSystem.Components.OnHitEffects;
using Assets.WeaponSystem;
using static StatsController;

public class EffectBleed : OnHitEffect
{
    /* Apply Nature typed DoT to target
    ** Damage is based on stats/level
    ** while legth is static
    */

    float coefficient = 0.01f;
    int time = 5;

    int ticks = 5;

    float amount = 0f;

    IWeaponTarget target = null;

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Vector3 position, Vector3 normal, Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
    {

        StatsController srcStats = weapon.owner.actor.statsController;
        this.target = target;

        Stat attackPower = srcStats.GetStat(StatType.AttackPower);

        this.amount = attackPower.BaseValue;
        this.amount += attackPower.CalculateStatValue() * coefficient;

        EffectDot dot = new EffectDot(target, time, ticks, new PhysicalDamage(amount / ticks));

        result.applyEffects = true;

        return result;
    }
}