using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components.AccuracyControllers
{
    public class SprayAccuracyController : AccuracyController
    {
        public override ComponentType componentType => ComponentType.AccuracyController;

        public float angleRange = 5f;

        public override (Vector3 position, Quaternion rotation, Vector3 direction) GetSpawnPosition(Weapon weapon, IWeaponTarget target, int projectileNumber)
        {
            (Vector3 position, Quaternion rotation, Vector3 direction) = GetDefaultSpawnPosition(weapon, target, projectileNumber);
            float value = Random.Range(-angleRange, angleRange);
            Quaternion offset = Quaternion.Euler(0f, 0f, value);
            return (position, offset * rotation, offset * direction);
        }
    }
}