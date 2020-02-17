using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInputEvent : IEvent
{
    public readonly Vector2 position, delta;

    public DragInputEvent(Vector2 position, Vector2 delta)
    {
        this.position = position;
        this.delta = delta;
    }
}
