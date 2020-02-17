using Assets.Scripts.Util;
using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.AccuracyControllers;
using Assets.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components.Triggers
{
    public class BurstTrigger : WeaponComponent
    {
        public override ComponentType componentType => ComponentType.Trigger;

        public int bulletCount = 5;
        public float burstTime = 0.25f;

        public override FireResult Fire(Weapon weapon, IWeaponTarget target, AccuracyController accuracyController, BulletSpawnInfo bulletSpawnInfo, FireResult result)
        {
            ProjectileFuture[] futures = new ProjectileFuture[bulletCount].Fill(() => new ProjectileFuture());
            result.AddProjectile(futures);
            StartCoroutine(BurstRoutine(weapon, target, accuracyController, bulletSpawnInfo, futures));
            return result;
        }

        public IEnumerator BurstRoutine(Weapon weapon, IWeaponTarget target, AccuracyController accuracyController, BulletSpawnInfo bulletSpawnInfo, ProjectileFuture[] futures)
        {
            for (int i = 0; i < futures.Length; i++)
            {
                var projectiles = weapon.CreateProjectile(target, accuracyController, bulletSpawnInfo, i);
                if (projectiles != null && projectiles.Count() > 0)
                {
                    futures[i].SetProjectile(projectiles.FirstOrDefault());
                }
                else
                {
                    futures[i].SetProjectile(null);
                }

                yield return new WaitForSeconds(burstTime / bulletCount);
            }
        }
    }
}