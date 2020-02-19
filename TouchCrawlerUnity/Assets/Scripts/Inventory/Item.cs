using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public string itemEffect = "No Effect";

    public int healthBuff = 0;
    public int attackBuff = 0;
    public int spAttackBuff = 0;
    public int defenceBuff = 0;
    public int spDefenceBuff = 0;
    public int speedBuff = 0;

    public bool NotAPickup = false;
}