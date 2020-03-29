using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer itemIcon;
    private bool isPickedUp = false;
    private GameObject[] itemSlots;
    public Item item;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
                // If Weapon, store inside inventory. Else, apply stats to player.
                if (gameObject.tag == "Weapon")
                {
                    actor.inventory.Add(item, gameObject);
                    Destroy(gameObject);
                    return true;
                }
                else
                {
                    // Equip buff to player
                    GameObject equippedBuff = Instantiate(gameObject,
                        new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, 0f),
                        new Quaternion(0, 0, 0, 0), player.transform);

                    equippedBuff.name = gameObject.name;

                    // Remove graphic when it's added to the player
                    equippedBuff.GetComponent<SpriteRenderer>().enabled = false;
                    equippedBuff.GetComponent<CircleCollider2D>().enabled = false;

                    Destroy(gameObject);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }

    private bool ValidatePickup(IActor actor)
    {
        if (actor == null || actor.inventory == null)
        {
            return false;
        }
        else if (actor.inventory.IsFull)
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