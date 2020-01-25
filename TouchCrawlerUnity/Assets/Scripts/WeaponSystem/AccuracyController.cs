using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public abstract class AccuracyController : WeaponComponent
    {
        public virtual (Vector3 position, Quaternion rotation, Vector3 direction) GetSpawnPosition(Weapon weapon, IWeaponTarget target)
        {
            return (default, default, default);
        }

        public static (Vector3 position, Quaternion rotation, Vector3 direction) GetDefaultSpawnPosition(Weapon weapon, IWeaponTarget target)
        {
            return (default, default, default);
        }
    }
}