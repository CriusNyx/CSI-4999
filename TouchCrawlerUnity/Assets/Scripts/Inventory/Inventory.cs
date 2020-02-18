using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, ICollection<Item>
{
    private List<Item> itemList = new List<Item>();
    private int maxNumber = 6;

    public bool IsFull
    {
        get
        {
            if (itemList.Count == maxNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public int Count => itemList.Count;

    public bool IsReadOnly => false;

    public void Add(Item item)
    {
        itemList.Add(item);
    }

    public void Clear()
    {
        itemList.Clear();
    }

    public bool Contains(Item item)
    {
        if (itemList.Contains(item))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CopyTo(Item[] array, int arrayIndex)
    {
        itemList.CopyTo(array, arrayIndex);
    }

    public IEnumerator<Item> GetEnumerator()
    {
        return itemList.GetEnumerator();
    }

    public bool Remove(Item item)
    {
        return itemList.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator) itemList.GetEnumerator();
    }
}