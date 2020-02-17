using System;
using UnityEngine;

[Serializable]
public class Damage {

    public ContactPoint2D[] Contact { get; private set;  } //TODO: Set on projectile logic prior to destroying projectile

    public Damage(ContactPoint2D[] contact) {
        if (contact != null) {
            this.Contact = contact;
        }
        //This is a constructor. It doesn't return itself.
        //This is not Javascript. lol
    }

    public Damage() {
        this.Contact = null;
    }
}