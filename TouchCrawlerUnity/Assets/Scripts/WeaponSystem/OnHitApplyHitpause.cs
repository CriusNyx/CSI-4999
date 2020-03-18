using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.OnHitEffects;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitApplyHitpause : OnHitEffect
{
    public float duration = 0.1f;
    public float trauma = 5f;

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Vector3 position, Vector3 normal, Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
    {
        var hitpauseController = target.gameObject.GetComponent<HitPauseController>();
        if(hitpauseController != null)
        {
            hitpauseController.StartShake(duration, trauma);
        }
        return result;
    }
}