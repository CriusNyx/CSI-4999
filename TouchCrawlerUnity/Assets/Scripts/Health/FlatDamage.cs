using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatDamage : Damage
{
    public readonly float damageAmount;
    public FlatDamage(float damageAmount, ContactPoint contactPoint):base(contactPoint)
    {
        this.damageAmount = damageAmount;
    }
}
