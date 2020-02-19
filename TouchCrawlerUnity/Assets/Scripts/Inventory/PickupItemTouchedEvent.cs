using Assets.Scripts.Events;
using UnityEngine;

public class PickupItemTouchedEvent : IEvent
{
    public readonly Item item;

    public PickupItemTouchedEvent(Item item)
    {
        this.item = item;
    }
}