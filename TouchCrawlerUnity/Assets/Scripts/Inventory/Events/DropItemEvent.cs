using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemEvent : IEvent
{
    public readonly Item item;

    public DropItemEvent(Item item)
    {
        this.item = item;
    }
}