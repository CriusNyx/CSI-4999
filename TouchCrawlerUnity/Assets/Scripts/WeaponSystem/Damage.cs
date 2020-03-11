using System;
using UnityEngine;

[Serializable]
public class Damage
{

    public ContactPoint2D[] Contact { get; private set; } //TODO: Set on projectile logic prior to destroying projectile

    public Damage(ContactPoint2D[] contact)
    {
        if (contact != null)
        {
            this.Contact = contact;
        }
        //This is a constructor. It doesn't return itself.
        //This is not Javascript. lol
    }

    public Damage()
    {
        this.Contact = null;
    }
}

[Serializable]
public class FlatDamage : Damage
{
    public float amount = 10f;

    public FlatDamage()
    {

    }

    public FlatDamage(float amount, ContactPoint2D[] contact) : base(contact)
    {
        this.amount = amount;
    }
}

[Serializable]
public class SpellDamage : Damage
{
    public float amount = 0f;
    public SpellDamage(int amount)
    {
        this.amount = amount;
    }
    public SpellDamage(float amount, ContactPoint2D[] contact) : base(contact)
    {
        this.amount = amount;
    }
}

[Serializable]
public class PhysicalDamage : Damage
{
    public float amount = 0f;
    public PhysicalDamage(int amount)
    {
        this.amount = amount;
    }

    public PhysicalDamage(float amount, ContactPoint2D[] contact) : base(contact)
    {
        this.amount = amount;
    }
}