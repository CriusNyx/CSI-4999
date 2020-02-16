using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTouchInputEvent : IEvent
{
    public readonly Item itemTouchable;

    public ItemTouchInputEvent(Item item)
    {
        this.itemTouchable = item;
    }
}
