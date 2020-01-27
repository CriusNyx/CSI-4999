using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components.AccuracyControllers
{
    public abstract class AccuracyController : WeaponComponent
    {
        public virtual (Vector3 position, Quaternion rotation, Vector3 direction) GetSpawnPosition(Weapon weapon, IWeaponTarget target, int projectileNumber)
        {
            return GetDefaultSpawnPosition(weapon, target, projectileNumber);
        }

        public static (Vector3 position, Quaternion rotation, Vector3 direction) GetDefaultSpawnPosition(Weapon weapon, IWeaponTarget target, int projectileNumber)
        {
            return (default, default, Vector3.right);
        }
    }
}