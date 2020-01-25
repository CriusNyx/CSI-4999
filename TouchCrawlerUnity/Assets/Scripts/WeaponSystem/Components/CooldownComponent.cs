using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components
{
    public class CooldownComponent : WeaponComponent
    {
        public Cooldown cooldown = new Cooldown();

        public override FireRequestResult RequestFire(Weapon weapon, IWeaponTarget target, FireRequestResult result)
        {
            if(cooldown.IsReady())
            {
                result.fireRequestSuccessful = true;
                result.AddProjectile(1);
            }
            return result;
        }

        public override FireResult Fire(Weapon weapon, IWeaponTarget target, AccuracyController accuracyController, FireResult result)
        {
            cooldown.TriggerCooldown();
            return result;
        }
    }
}

