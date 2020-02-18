using Assets.Scripts.Events;
using Assets.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : DefaultActor
{
    public override void AcceptEvent(IEvent e)
    {
        base.AcceptEvent(e);

        if (e is PickupItemTouchedEvent pickupItemEvent)
        {
            this.inventory.Add(pickupItemEvent.item);
            DestroyImmediate(pickupItemEvent.item);

            Debug.Log("Picked up: " + pickupItemEvent.item.name);
        }
    }

    public void PlayerPickUp(Item item)
    {
        this.inventory.Add(item);
    }
}