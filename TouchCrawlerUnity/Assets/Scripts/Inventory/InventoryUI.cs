using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private GameObject player;
    private IActor actor;
    private GameObject[] itemSlots;
    private SpriteRenderer itemIcon;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        itemSlots = GameObject.FindGameObjectsWithTag("Item Slot");
        actor = player.GetComponent<IActor>();

        Inventory inventory = actor.inventory;

        // If you do += these methods will run recursively, which is bad
        inventory.onPickUp = OnPickUp;
        inventory.onDrop = OnDrop;
    }

    public void OnPickUp(Item item, GameObject itemObject)
    {
        foreach (GameObject itemSlot in itemSlots)
        {
            if (itemSlot.transform.transform.childCount < 2)
            {
                Image image = itemSlot.transform.Find("ItemIcon").GetComponent<Image>();
                //itemIcon = image.GetComponent<SpriteRenderer>();

                image.enabled = true;
                image.sprite = item.icon;
                image.color = item.color;

                // Create a clone of the item within item slot
                GameObject clone = Instantiate(itemObject, itemSlot.transform, false);
                clone.name = item.name;

                break;
            }
        }

        return;
    }

    public void OnDrop(Item item, bool success)
    {
        if (success)
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Failed");
        }
    }
}
