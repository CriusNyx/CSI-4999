using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components.AccuracyControllers
{
    public class SpreadAccuracyController : AccuracyController
    {
        public override ComponentType componentType => ComponentType.AccuracyController;

        public float angleBetweenBullets = 2.5f;

        public override (Vector3 position, Quaternion rotation, Vector3 direction) GetSpawnPosition(Weapon weapon, IWeaponTarget target, int projectileNumber)
        {
            (Vector3 position, Quaternion rotation, Vector3 direction) = GetDefaultSpawnPosition(weapon, target, 0);
            if (projectileNumber == 0)
            {
                return (position, rotation, direction);
            }
            else if (projectileNumber % 2 == 0)
            {
                Quaternion offset = Quaternion.Euler(0f, 0f, projectileNumber / 2 * angleBetweenBullets);
                return (position, offset * rotation, offset * direction);
            }
            else
            {
                Quaternion offset = Quaternion.Euler(0f, 0f, (projectileNumber + 1) / -2 * angleBetweenBullets);
                return (position, offset * rotation, offset * direction);
            }
        }
    }
}