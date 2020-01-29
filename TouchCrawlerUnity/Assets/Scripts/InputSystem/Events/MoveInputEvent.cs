using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputEvent : IEvent
{
    public readonly Ray ray;

    public MoveInputEvent(Ray ray)
    {
        this.ray = ray;
    }
}
