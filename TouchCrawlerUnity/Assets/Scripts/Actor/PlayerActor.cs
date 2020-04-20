using Assets.Scripts.Events;
using Assets.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : DefaultActor
{
    private GameObject gui;
    private bool escapeOpen = false;
    public static PlayerActor Instance { get; private set; }

    private GameObject player;
    //private IActor actor;
    private GameObject[] itemSlots;

    protected override void ProtectedStart()
    {
        base.ProtectedStart();

        Instance = this;
        gui = GameObject.Instantiate(Resources.Load("Prefabs/GUIs/GameOverScreen")) as GameObject;
        gui.SetActive(false);
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
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                if (gui == null)
                {
                    gui = GameObject.Instantiate(Resources.Load("Prefabs/GUIs/EscapeScreen")) as GameObject;
                    gui.SetActive(false);
                }
                if (!gui.activeSelf && !escapeOpen)
                {
                    gui.SetActive(true);
                }
                else
                {
                    gui.SetActive(false);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            escapeOpen = !escapeOpen;
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
            //string itemName = String.IsNullOrEmpty(pickupItemEvent.item.name) ? "Consumable" : "Test";
            //Debug.Log("Player: PickupItemTouchedEvent - " + itemName);
        }
    }

    public override void OnRoomEnter(RoomController roomController)
    {
        base.OnRoomEnter(roomController);

        //Viewport.Instance.CameraController.objectToTrack = gameObject;
        Viewport.Instance.CameraController.target = roomController.CameraTarget;
    }
}