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

    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            foreach (Item item in this.inventory.itemList)
            {
                Debug.Log(item.name);
            }

            Debug.Log("Count: " + this.inventory.itemList.Count);
        }
    }

    public override void AcceptEvent(IEvent e)
    {
        base.AcceptEvent(e);

        if (e is DropItemEvent dropItemEvent)
        {
            Debug.Log("Player: DropItemEvent - " + dropItemEvent.item.name);
            //this.inventory.Remove(dropItemEvent.item);
        }

        if (e is PickupItemTouchedEvent pickupItemEvent)
        {
            Debug.Log("Player: PickupItemTouchedEvent - " + pickupItemEvent.item.name);
        }
    }
}