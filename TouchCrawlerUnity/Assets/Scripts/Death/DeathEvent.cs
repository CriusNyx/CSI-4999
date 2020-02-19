using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEvent : IEvent
{
    public readonly IActor actor;

    public DeathEvent(IActor actor)
    {
        this.actor = actor;
    }

}
