using Assets.Scripts.Util.Latches;
using Assets.Scripts.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitEffect : WeaponComponent
{
    public override ComponentType componentType => ComponentType.OnHitEffect;

    public MasterLatch latch = new MasterLatch();

    public DummyDamage damage;

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result) {
        if (ApplyDebuff(target)) {
            SpawnAnimation(target.gameObject.location);
            result.applyEffects = true;
        }
        return result;
    } 
    private bool ApplyDebuff(IWeaponTarget target) {
        //TODO: Debuffs
        //Get Target Actor
        //Apply debuff to target
        //Return based on success of applying debuff
        throw new System.NotImplementedException();
    }

    private void SpawnAnimation(Vector2 location) {
        throw new System.NotImplementedException();
    }
}