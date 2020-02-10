using Assets.Scripts.Events;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor : IEventListener, IWeaponTarget, IWeaponOwner
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

    Vector2 GetLocation();

    Vector2 DistanceToDestination();

    void UseItem(object item);

    void PickUpItem(object item);

    Weapon.WeaponTargetType AttackWeaponTargetType { get; }
    Weapon.WeaponTargetType DefenseWeaponTargetType { get; }
}
