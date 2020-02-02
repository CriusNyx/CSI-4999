using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : WeaponComponent
{
    public override CreateProjectileResult CreateProjectile(Weapon weapon, IWeaponTarget target, Vector3 position, Quaternion rotation, Vector3 direction, CreateProjectileResult result)
    {

    }
}
