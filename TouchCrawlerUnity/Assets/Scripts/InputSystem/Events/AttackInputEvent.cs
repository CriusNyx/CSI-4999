using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInputEvent : IEvent
{
    public readonly Attackable attackable;

    public AttackInputEvent(Attackable attackable)
    {
        this.attackable = attackable;
    }
}
