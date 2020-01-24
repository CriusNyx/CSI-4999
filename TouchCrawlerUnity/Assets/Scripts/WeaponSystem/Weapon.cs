using Assets.Scripts.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        public IWeaponOwner owner { get; }
        public WeaponStatBlock baseStats { get; private set; }

        public IEnumerable<WeaponComponent> GetAllComponents()
        {
            return gameObject.GetComponentsInChildren<WeaponComponent>();
        }

        public (bool cooldownPassed, bool weaponFired, IEnumerable<IProjectile> projectiles) Fire(IWeaponTarget target)
        {
            var components = GetAllComponents();
            WeaponComponent.FireRequestResult requestResult = new WeaponComponent.FireRequestResult();
            foreach(var component in components)
            {
                requestResult = component.RequestFire(this, target, requestResult);
            }

            if(requestResult.fireRequestSuccessful)
            {
                WeaponComponent.FireResult fireResult = new WeaponComponent.FireResult();
                for(int i = 0; i < requestResult.projectileCount; i++)
                {
                    foreach(var component in components)
                    {
                        fireResult = component.Fire(this, target, fireResult);
                    }
                }
                return (requestResult.fireRequestSuccessful, fireResult.success, fireResult.projectiles);
            }

            return (requestResult.fireRequestSuccessful, false, null);
        }

        public IEnumerable<IProjectile> CreateProjectile(IWeaponTarget target, Vector3 position, Quaternion rotation, Vector3 direction)
        {
            var components = GetAllComponents();
            WeaponComponent.CreateProjectileResult result = new WeaponComponent.CreateProjectileResult();

            foreach(var component in components)
            {
                result = component.CreateProjectile(this, target, position, rotation, direction, result);
            }
            return result.projectiles;
        }

        public void ApplyOnHitEffects(IWeaponTarget target)
        {
            var components = GetAllComponents();
            WeaponComponent.ApplyOnHitEffectsResult result = new WeaponComponent.ApplyOnHitEffectsResult();
            foreach(var component in components)
            {
                result = component.ApplyOnHitEffects(this, target, result);
            }
        }

        public WeaponStatBlock GetStats()
        {
            var components = GetAllComponents();
            WeaponComponent.GetStatsResult result = new WeaponComponent.GetStatsResult();
            foreach(var component in components)
            {
                result = component.GetStats(this, result);
            }
            return result.block;
        }

        public string GetName()
        {
            var components = GetAllComponents();
            WeaponComponent.GetNameResult result = new WeaponComponent.GetNameResult();

            foreach(var component in components)
            {
                result = component.GetName(this, result);
            }

            return result.ToString();
        }

        public void GetGraphics()
        {
            var components = GetAllComponents();
            WeaponComponent.GetGraphicsResult result = new WeaponComponent.GetGraphicsResult();

            foreach(var component in components)
            {
                result = component.GetGraphics(this, result);
            }

            throw new NotImplementedException("Weapon Graphics is not fully implimented");
        }

        public int GetCost()
        {
            var components = GetAllComponents();
            WeaponComponent.GetCostResult result = new WeaponComponent.GetCostResult();

            foreach(var component in components)
            {
                result = component.GetCost(this, result);
            }
            return result.cost;
        }

        public bool ShouldDestroyProjectile(IProjectile projectile, RaycastHit2D raycastHit)
        {
            var components = GetAllComponents();
            WeaponComponent.ShouldDestroyProjectileResult result = new WeaponComponent.ShouldDestroyProjectileResult();

            foreach(var component in components)
            {
                result = component.ShouldDestroyProjectile(this, projectile, raycastHit, result);
            }

            return result.shouldDestroy;
        }
    }
}
