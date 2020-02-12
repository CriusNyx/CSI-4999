using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.AccuracyControllers;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components.Triggers
{
    public class ShotgunTrigger : WeaponComponent
    {
        public override ComponentType componentType => ComponentType.Trigger;

        public int projectileCount = 5;

        public override FireResult Fire(Weapon weapon, IWeaponTarget target, AccuracyController accuracyController, BulletSpawnInfo bulletSpawnInfo, FireResult result)
        {
            result.success = true;

            for (int i = 0; i < projectileCount; i++)
            {
                result.AddProjectile(weapon.CreateProjectile(target, accuracyController, bulletSpawnInfo, i));
            }
            return result;
        }
    }
}