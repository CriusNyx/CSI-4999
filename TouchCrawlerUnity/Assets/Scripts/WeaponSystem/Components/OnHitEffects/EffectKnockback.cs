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

    protected override void ApplyKnockback(Weapon weapon, IWeaponTarget target) {
        throw new System.NotImplementedException();

        //ContactPoint contact = weapon.Damage().Contact()[0];

        //TODO: Verify this is correct logic
        //Vector2 direction = (target.gameObject.transform.position - target.gameObject.transform.InverseTransformPoint(contact).position).normalized; 
        //target.gameObject.GetComponent<Rigidbody>().AddForce(direction * 2); //TODO: Static number for testing

        //return true;
    }

}