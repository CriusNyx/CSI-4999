using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable Item")]
public class ConsumableItem : ScriptableObject
{
    public ConsumableType consumableType;

    public enum ConsumableType
    {
        Health,
    }

    public int value = 0;
}
