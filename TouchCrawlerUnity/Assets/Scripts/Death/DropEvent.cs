using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEvent : IEvent
{
    public readonly Vector3 location;

    public DropEvent(IActor actor)
    {
        this.location = actor.gameObject.transform.position;
    }

    public DropEvent(Vector3 location)
    {
        this.location = location;
    }

}
