using Assets.Scripts.Events;
using UnityEngine;

public class PickupItemTouchedEvent : IEvent
{
    public readonly Item item;
    public readonly GameObject itemObject;

    public PickupItemTouchedEvent(Item item, GameObject itemObject)
    {
        this.item = item;
        this.itemObject = itemObject;
    }
}