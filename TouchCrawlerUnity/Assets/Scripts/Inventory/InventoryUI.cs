using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private GameObject player;
    private IActor actor;
    private GameObject selectedSlot;
    private GameObject[] itemSlots;
    private SpriteRenderer itemIcon;
    private Image image;

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
                image = itemSlot.transform.Find("ItemIcon").GetComponent<Image>();
                //itemIcon = image.GetComponent<SpriteRenderer>();
     
                image.enabled = true;
                image.sprite = item.icon;
                image.color = item.color;
                image.GetComponent<InventoryIcon>().item = item;

                // Create a clone of the item within item slot
                GameObject clone = Instantiate(itemObject, itemSlot.transform, false);
                clone.name = item.name;

                break;
            }
        }

        return;
    }

    public void OnDrop(Item item, GameObject itemSlot, bool success)
    {
        if (success && itemSlot.transform.childCount > 1)
        {
            image = itemSlot.transform.GetChild(0).GetComponent<Image>();

            image.enabled = false;
            image.sprite = null;
            image.color = Color.white;
            image.GetComponent<InventoryIcon>().item = null;

            Destroy(itemSlot.transform.GetChild(1).gameObject);
        }
    }
}
