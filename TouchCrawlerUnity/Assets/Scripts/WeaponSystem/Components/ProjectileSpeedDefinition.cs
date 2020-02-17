using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpeedDefinition : WeaponComponent
{
    public override ComponentType componentType => ComponentType.None;

    public float speedModifierRatio = 1.0f;

    public override FireRequestResult RequestFire(Weapon weapon, IWeaponTarget target, FireRequestResult result)
    {
        result.spawnInfo.AddSpeedModRatio(speedModifierRatio);
        return result;
    }
}