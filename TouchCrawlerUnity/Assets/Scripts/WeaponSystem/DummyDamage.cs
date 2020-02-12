using UnityEngine;

public class Damage {

    public ContactPoint contact { get; private set;  } //TODO: Set on projectile logic prior to destroying projectile
    public IActor weaponOwner { get; private set; }
    public Damage(ContactPoint contact, IActor weaponOwner) {
        this.contact = contact;
        this.weaponOwner = weaponOwner;
        //This is a constructor. It doesn't return itself.
        //This is not Javascript. lol
    }
}

public class DummyDamage : Damage
{
    public DummyDamage(ContactPoint contact, IActor weaponOwner) : base(contact, weaponOwner)
    {
    }
}