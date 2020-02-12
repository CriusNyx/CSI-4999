using System;
using UnityEngine;

public class Damage {

    public ContactPoint contact { get; private set;  } //TODO: Set on projectile logic prior to destroying projectile

    public Damage(ContactPoint contact) {
        this.contact = contact;
        //This is a constructor. It doesn't return itself.
        //This is not Javascript. lol
    }

}

public class DummyDamage : Damage
{
    public DummyDamage(ContactPoint contact) : base(contact)
    {
    }
}