using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components
{
    public class SingleActionTrigger : WeaponComponent
    {
        public override FireResult Fire(Weapon weapon, IWeaponTarget target, FireResult result)
        {
            result.success = true;

            result.AddProjectile(weapon.CreateProjectile(target, Vector3.zero, Quaternion.identity, Vector3.up));

            return result;
        }
    }
}