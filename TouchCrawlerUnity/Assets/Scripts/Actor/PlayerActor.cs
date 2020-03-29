using Assets.Scripts.Events;
using Assets.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : DefaultActor
{
    public static PlayerActor Instance { get; private set; }

    private GameObject player;
    //private IActor actor;
    private GameObject[] itemSlots;

    protected override void ProtectedStart()
    {
        base.ProtectedStart();

        Instance = this;

        player = GameObject.FindGameObjectWithTag("Player");
        itemSlots = GameObject.FindGameObjectsWithTag("Item Slot");
        //actor = player.GetComponent<IActor>();

        Viewport.Instance.CameraController.objectToTrack = gameObject;
    }

    // Debug to see how many items the player has. -Sam
    void Update()
    {
        if(Input.GetKey(KeyCode.I))
        {
            foreach(Item item in this.inventory.itemList)
            {
                Debug.Log(item.name);
            }
        }
    }

    public override void AcceptEvent(IEvent e)
    {
        base.AcceptEvent(e);

        if(e is DropItemEvent dropItemEvent)
        {
            Debug.Log("Player: DropItemEvent - " + dropItemEvent.item.name);
            this.inventory.Remove(dropItemEvent.item, dropItemEvent.itemSlot);
        }

        if(e is PickupItemTouchedEvent pickupItemEvent)
        {
            Debug.Log("Player: PickupItemTouchedEvent - " + pickupItemEvent.item.name);
        }
    }

    public override void OnRoomEnter(RoomController roomController)
    {
        base.OnRoomEnter(roomController);

        //Viewport.Instance.CameraController.objectToTrack = gameObject;
        Viewport.Instance.CameraController.target = roomController.CameraTarget;
    }
}