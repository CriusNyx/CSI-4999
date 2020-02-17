using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput
{
    public enum EventType
    {
        down,
        drag,
        up
    }

    public readonly EventType eventType;
    public readonly Vector2 delta;
    public readonly Vector2 inputPosition;

    public GameInput(EventType eventType, Vector2 delta, Vector2 inputPosition)
    {
        this.eventType = eventType;
        this.delta = delta;
        this.inputPosition = inputPosition;
    }
}