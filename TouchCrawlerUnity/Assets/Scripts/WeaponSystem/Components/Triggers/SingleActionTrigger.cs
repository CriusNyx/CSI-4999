using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.AccuracyControllers;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components.Triggers
{
    public class SingleActionTrigger : WeaponComponent
    {
        public override ComponentType componentType => ComponentType.Trigger;

        public override FireResult Fire(Weapon weapon, IWeaponTarget target, AccuracyController accuracyController, FireResult result)
        {
            result.success = true;

            result.AddProjectile(weapon.CreateProjectile(target, accuracyController, 0));

            return result;
        }
    }
}