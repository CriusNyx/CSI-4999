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
                foreach(GameObject itemSlot in itemSlots)
                {
                    if (itemSlot.transform.transform.childCount < 2)
                    {
                        actor.inventory.Add(item);

                        Image image = itemSlot.transform.Find("ItemIcon").GetComponent<Image>();
                        itemIcon = this.GetComponent<SpriteRenderer>();

                        image.enabled = true;
                        image.sprite = itemIcon.sprite;
                        image.color = itemIcon.color;

                        // Create a clone of the item within item slot
                        GameObject clone = Instantiate(gameObject, itemSlot.transform, false);
                        clone.name = item.name;

                        Destroy(gameObject);

                        return true;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }
    }

    private bool ValidatePickup(IActor actor)
    {
        // Check if inventory is full
        if (actor.inventory.IsFull)
        {
            return false;
        }
        else
        {
            // Allow pick up
            return true;
        }
    }
}