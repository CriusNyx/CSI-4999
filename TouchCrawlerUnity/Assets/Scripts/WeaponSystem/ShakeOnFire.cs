using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnFire : WeaponComponent
{
    public float trauma = 1f, length = 0.1f;

    public override ComponentType componentType => ComponentType.None;

    public override CreateProjectileResult CreateProjectile(Weapon weapon, IWeaponTarget target, Vector3 position, Quaternion rotation, Vector3 direction, BulletSpawnInfo bulletSpawnInfo, CreateProjectileResult result)
    {
        ScreenShakeController.StartShake(trauma, length);
        return result;
    }
}
