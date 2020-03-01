using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, ICollection<Item>
{
    // Made this public for debugging purposes
    public List<Item> itemList = new List<Item>();
    private int maxNumber = 6;
    public Action<Item, GameObject> onPickUp;
    public Action<Item, bool> onDrop;

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

    public void Add(Item item, GameObject itemObject)
    {
        itemList.Add(item);
        onPickUp?.Invoke(item, itemObject);
    }

    public void Add(Item item)
    {
        Debug.Log("Don't call Inventory.Add() without GameObject");
    }

    public bool Remove(Item item)
    {
        var remove = itemList.Remove(item);
        onDrop?.Invoke(item, remove);

        return remove;
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

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator) itemList.GetEnumerator();
    }
}