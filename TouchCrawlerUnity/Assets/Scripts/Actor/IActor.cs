using Assets.Scripts.Events;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor : IEventListener, IWeaponTarget
{
    int actorLevel {
        get;
        set;
    }

    IActor target
    {
        get;
        set;
    }
    MovementController movementController
    {
        get;
    }

    Weapon weapon
    {
        get;
    }

    bool IsPlayer();

    void UseItem(Item item);

    void PickUpItem(Item item);

    Weapon.WeaponTargetType AttackWeaponTargetType { get; }
    Weapon.WeaponTargetType DefenseWeaponTargetType { get; }

    Inventory inventory { get; }
}
