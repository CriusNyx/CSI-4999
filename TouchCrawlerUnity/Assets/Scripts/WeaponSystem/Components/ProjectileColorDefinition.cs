using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileColorDefinition : WeaponComponent
{
    public override ComponentType componentType => ComponentType.None;

    public Color color = Color.white;

    public override FireRequestResult RequestFire(Weapon weapon, IWeaponTarget target, FireRequestResult result)
    {
        result.spawnInfo.color = color;
        return base.RequestFire(weapon, target, result);
    }
}