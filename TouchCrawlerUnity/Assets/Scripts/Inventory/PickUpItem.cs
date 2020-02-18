using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private SpriteRenderer itemIcon;
    private bool isPickedUp = false;
    public Item item;

    // Checks to see if player collides with item
    private void OnTriggerEnter2D(Collider2D collider)
    {
        IActor actor = collider.GetComponentInParent<IActor>();

        if (actor != null)
        {
            actor.AcceptEvent(new PickupItemTouchedEvent(item, this.gameObject));
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
            //Check if item can be picked up
            isPickedUp = ValidatePickup(actor);
            Debug.Log("Inside RequestPickup");
            if (isPickedUp)
            {

                //Destroy self
                //Add self to actor inventory
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
        throw new NotImplementedException();
    }
}