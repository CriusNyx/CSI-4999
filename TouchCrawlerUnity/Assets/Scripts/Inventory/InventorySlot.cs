using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private Inventory inventory;
    public int index;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        //if (transform.childCount <= 0)
        //{
        //    inventory.items[index] = 0;
        //}
    }
}
