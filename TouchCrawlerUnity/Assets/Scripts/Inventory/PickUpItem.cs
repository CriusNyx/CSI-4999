using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private SpriteRenderer itemIcon;
    private bool isPickedUp = false;
    private GameObject[] itemSlots;
    public Item item;

    void Start()
    {
        itemSlots = GameObject.FindGameObjectsWithTag("Item Slot");
    }

    // Checks to see if player collides with item
    private void OnTriggerEnter2D(Collider2D collider)
    {
        IActor actor = collider.GetComponentInParent<IActor>();
        
        if (actor != null)
        {
            if (RequestPickup(actor))
            {
                actor.AcceptEvent(new PickupItemTouchedEvent(item));
            }
            else
            {
                Debug.Log("Cannot be picked up! Check if inventory is full.");
            }
        }
    }

    public bool RequestPickup(IActor actor)
    {
        if (isPickedUp)
        {
            return false;
        }
        else
        {
            // Check if item can be picked up
            isPickedUp = ValidatePickup(actor);
            //Debug.Log("Inside RequestPickup");

            if (isPickedUp)
            {
                actor.inventory.Add(item, gameObject);
                Destroy(gameObject);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private bool ValidatePickup(IActor actor)
    {
        if(actor == null || actor.inventory == null)
        {
            return false;
        }
        else if(actor.inventory.IsFull)
        {
            return false;
        }
        // Check if inventory is full
        else
        {
            // Allow pick up
            return true;
        }
    }
}