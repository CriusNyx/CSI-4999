using Assets.Scripts.Util.Latches;
using Assets.Scripts.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.WeaponSystem.Components.OnHitEffects;
using Assets.WeaponSystem;

public class EffectKnockback : OnHitEffect
{ 
    /* Single target knockback
    ** Moves target in opposite direction
    ** of bullet hit.
    */

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Vector3 position, Vector3 normal, Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result) {
        return result;
    }

}