using Assets.Scripts.Util;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components.AccuracyControllers
{
    public class PatternAccuracyController : AccuracyController
    {
        public override ComponentType componentType => ComponentType.AccuracyController;

        public float[] spawnAngles = new float[] { };

        public override (Vector3 position, Quaternion rotation, Vector3 direction) GetSpawnPosition(Weapon weapon, IWeaponTarget target, int projectileNumber)
        {
            (Vector3 position, Quaternion rotation, Vector3 direction) = GetDefaultSpawnPosition(weapon, target, projectileNumber);

            if (spawnAngles.BoundsCheck(projectileNumber))
            {
                Quaternion offset = Quaternion.Euler(0f, 0f, spawnAngles[projectileNumber]);
                return (position, offset * rotation, offset * direction);
            }
            else
            {
                return (position, rotation, direction);
            }
        }
    }
}