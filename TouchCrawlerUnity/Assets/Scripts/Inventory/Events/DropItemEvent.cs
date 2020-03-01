using Assets.Scripts.Events;
using UnityEngine;

public class DropItemEvent : IEvent
{
    public readonly Item item;
    public readonly GameObject itemSlot;

    public DropItemEvent(Item item, GameObject itemSlot)
    {
        this.item = item;
        this.itemSlot = itemSlot;
    }
}