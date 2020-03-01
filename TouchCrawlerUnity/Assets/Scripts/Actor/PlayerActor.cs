using Assets.Scripts.Events;
using Assets.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : DefaultActor
{
    protected override void ProtectedStart()
    {
        base.ProtectedStart();

        Viewport.Instance.CameraController.objectToTrack = gameObject;
    }

    // Debug to see how many items the player has. -Sam
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

        if (e is PickupItemTouchedEvent pickupItemEvent)
        {
            Debug.Log("PickupItemTouchedEvent");
        }
    }

    public override void OnRoomEnter(RoomController roomController)
    {
        base.OnRoomEnter(roomController);

        //Viewport.Instance.CameraController.objectToTrack = gameObject;
        Viewport.Instance.CameraController.target = roomController.CameraTarget;
    }
}