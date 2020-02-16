using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;
    private GameObject[] itemSlots;
    private SpriteRenderer itemIcon;

    private void Start()
    {
        // Get Player prefab, get ItemSlot prefabs
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        itemSlots = GameObject.FindGameObjectsWithTag("Item Slot");
    }

    // Checks to see if player collides with item
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0)
                {
                    // Store item into inventory
                    inventory.items[i] = 1;

                    // Set the image and color, if applicable, of the item picked up
                    Image image = itemSlots[i].transform.Find("ItemIcon").GetComponent<Image>();

                    if (!image.enabled)
                    {
                        image.enabled = true;

                        itemIcon = this.GetComponent<SpriteRenderer>();
                        image.sprite = itemIcon.sprite;
                        image.color = itemIcon.color;
                    }
                    else
                    {
                        itemIcon = gameObject.GetComponent<SpriteRenderer>();
                        image.sprite = itemIcon.sprite;
                        image.color = itemIcon.color;
                    }

                    // Remove item from overworld
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
