using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDefinition : WeaponComponent
{
    public GameObject prefab;

    public override ComponentType componentType => ComponentType.ProjectileDefinition;

    public override FireRequestResult RequestFire(Weapon weapon, IWeaponTarget target, FireRequestResult result)
    {
        result.spawnInfo.prefabToSpawn = prefab;
        return result;
    }
}