using Assets.Scripts.Events;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor : IEventListener, IWeaponTarget, IWeaponOwner
{
    int actorLevel
    {
        get;
        set;
    }

    IActor target
    {
        get;
        set;
    }

    IActor attacker
    {
        get;
    }
    MovementController movementController
    {
        get;
    }

    Weapon weapon
    {
        get;
    }

    HealthController healthController
    {
        get;
    }

    bool IsPlayer();


    void UseItem(Item item);

    Vector2 GetLocation();

    Vector2 DistanceToDestination();

    void PickUpItem(Item item);

    Weapon.WeaponTargetType AttackWeaponTargetType { get; }
    Weapon.WeaponTargetType DefenseWeaponTargetType { get; }

    Inventory inventory { get; }
}
