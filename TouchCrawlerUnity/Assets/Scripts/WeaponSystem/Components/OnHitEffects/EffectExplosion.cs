using Assets.Scripts.Util.Latches;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExplosion : EffectAOE
{ 
    /* AoE physical damage to all
    ** targets in range.
    ** Range is static
    */
    int range = 2;

    public override ApplyOnHitEffectsResult ApplyOnHitEffects(Vector3 position, Vector3 normal, Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result) {
        List<IWeaponTarget> targets = GetTargetsInRadius(target.gameObject.transform.position, range);
        SpawnAnimation(new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y));
        foreach (IWeaponTarget tar in targets) {
            throw new System.NotImplementedException();
            //tar.DoDamage(new DummyDamage(null)); //TODO: Modify when damage system implemented. 
        }


        //Justin Fix
        throw new System.NotImplementedException();
    }

    //TODO: Explosion Animations
    protected override void SpawnAnimation(Vector2 location) {
        throw new System.NotImplementedException();
    }
}