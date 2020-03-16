using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private GameObject player;
    private IActor actor;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        actor = player.GetComponent<IActor>();
    }

    public void EquipWeapon()
    {
        // Checks if the inventory slot has an item
        if (gameObject.transform.childCount > 1)
        {
            if (player.transform.childCount > 0)
            {
                // Item already equipped.. swap out
                Debug.Log("An item is already equipped!");
            }
            else
            {
                // Equip weapon to Player
                GameObject itemObject = gameObject.transform.GetChild(1).gameObject;
                GameObject equippedWeapon = Instantiate(itemObject,
                    new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, 0f),
                    new Quaternion(0, 0, 0, 0), player.transform);

                equippedWeapon.name = itemObject.name;
                equippedWeapon.GetComponent<CircleCollider2D>().enabled = false;
            }
        }
        else
        {
            // Empty inventory slot
        }
    }
}
