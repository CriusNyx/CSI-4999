using Assets.Scripts.Events;
using Assets.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : DefaultActor
{
    private GameObject player;
    private IActor actor;
    private GameObject[] itemSlots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        itemSlots = GameObject.FindGameObjectsWithTag("Item Slot");
        actor = player.GetComponent<IActor>();
    }

    public override void AcceptEvent(IEvent e)
    {
        base.AcceptEvent(e);

        if (e is DropItemEvent dropItemEvent)
        {
            Debug.Log("Player: DropItemEvent - " + dropItemEvent.item.name);
            this.inventory.Remove(dropItemEvent.item, dropItemEvent.itemSlot);
        }

        if (e is PickupItemTouchedEvent pickupItemEvent)
        {
            Debug.Log("Player: PickupItemTouchedEvent - " + pickupItemEvent.item.name);
        }
    }
}