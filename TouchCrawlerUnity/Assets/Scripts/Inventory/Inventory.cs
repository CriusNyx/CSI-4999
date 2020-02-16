using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour/*, ICollection<Item>*/
{
    private List<Item> itemList = new List<Item>();
    private int maxNumber = 6;

    public bool IsFull
    {
        get
        {
            throw new NotImplementedException();
        }
    }
}