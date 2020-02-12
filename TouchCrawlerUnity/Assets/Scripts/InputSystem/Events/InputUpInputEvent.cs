using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputUpInputEvent : IEvent
{
    public readonly Vector2 position;

    public InputUpInputEvent(Vector2 position)
    {
        this.position = position;
    }
}
