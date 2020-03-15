using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.OnHitEffects;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnHit : OnHitEffect
{
    public GameObject particleGameObject;

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Vector3 position, Vector3 normal, Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
    {
        //Debug.Break();
        ParticleFunctions.PlayOneOff(particleGameObject, position + Vector3.back * 0.1f, Quaternion.LookRotation(Vector3.forward, normal));

        return result;
    }
}