using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components
{
    public class ProjectileFactoryDrawBullets : WeaponComponent
    {
        public override ComponentType componentType => ComponentType.Debug;

        public Color color = Color.white;
        public float time = 1f;

        public override CreateProjectileResult CreateProjectile(Weapon weapon, IWeaponTarget target, Vector3 position, Quaternion rotation, Vector3 direction, CreateProjectileResult result)
        {
            //Debug.Log("fire position = " + (position, rotation, direction).ToString());
            Debug.DrawRay(position, direction, color, time);
            return result;
        }
    }
}