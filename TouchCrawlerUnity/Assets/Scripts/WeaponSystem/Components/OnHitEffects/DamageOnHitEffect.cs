using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.OnHitEffects;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHitEffect : OnHitEffect
{
    public FlatDamage damage = new FlatDamage();

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Vector3 position, Vector3 normal, Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
    {
        result.applyEffects = true;
        target.DoDamage(damage);
        return result;
    }
}