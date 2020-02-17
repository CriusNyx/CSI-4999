using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.OnHitEffects;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHitEffect : OnHitEffect
{
    public Damage damage = new Damage();

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
    {
        result.applyEffects = true;
        target.DoDamage(damage);
        return result;
    }
}