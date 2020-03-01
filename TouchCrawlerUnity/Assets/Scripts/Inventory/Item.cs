using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{
    public GameObject prefab;
    public Sprite icon = null;
    public Color color = Color.white;

    public string itemEffect = "No Effect";

    public bool NotAPickup = false;
}