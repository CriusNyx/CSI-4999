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
            Debug.Log("PickupItemTouchedEvent");
            this.PickUpItem(pickupItemEvent.item);
            Destroy(pickupItemEvent.itemObject);
        }
    }
}