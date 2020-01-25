using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTrigger : WeaponComponent
{
    public int projectileCount = 5;

    public override FireResult Fire(Weapon weapon, IWeaponTarget target, AccuracyController accuracyController, FireResult result)
    {
        result.success = true;

        for(int i = 0; i < projectileCount; i++)
        {
            result.AddProjectile(weapon.CreateProjectile(target, accuracyController));
        }
        return result;
    }
}