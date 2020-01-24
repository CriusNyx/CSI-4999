using Assets.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public abstract class WeaponComponent : MonoBehaviour
    {
        public virtual FireRequestResult RequestFire(Weapon weapon, IWeaponTarget target, FireRequestResult result)
        {
            return result;
        }

        public class FireRequestResult
        {
            public bool fireRequestSuccessful = false;
            public int projectileCount { get; private set; } = 0;

            public void AddProjectile(int count)
            {
                projectileCount += count;
            }

            public void RemoveProjectile(int count)
            {
                projectileCount -= count;
            }
        }

        public virtual FireResult Fire(Weapon weapon, IWeaponTarget target, FireResult result)
        {
            return result;
        }

        public class FireResult
        {
            public bool success = false;
            private List<IProjectile> projectileList = new List<IProjectile>();
            public IEnumerable<IProjectile> projectiles => projectileList;

            public void AddProjectile(IEnumerable<IProjectile> projectiles)
            {
                projectileList.AddRange(projectiles);
            }
        }

        public virtual CreateProjectileResult CreateProjectile(Weapon weapon, IWeaponTarget target, Vector3 position, Quaternion rotation, Vector3 direction, CreateProjectileResult result)
        {
            return result;
        }

        public class CreateProjectileResult
        {
            public IEnumerable<IProjectile> projectiles => projectileList;
            private List<IProjectile> projectileList = new List<IProjectile>();

            public void Add(IProjectile projectile) => projectileList.Add(projectile);
        }

        public virtual ApplyOnHitEffectsResult ApplyOnHitEffects(Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
        {
            return result;
        }

        public class ApplyOnHitEffectsResult
        {
            public bool applyEffects = false;
        }

        public virtual GetStatsResult GetStats(Weapon weapon, GetStatsResult result)
        {
            return result;
        }

        public class GetStatsResult
        {
            public WeaponStatBlock block = new WeaponStatBlock();
        }

        public virtual GetNameResult GetName(Weapon weapon, GetNameResult result)
        {
            return result;
        }

        public class GetNameResult
        {
            public override string ToString()
            {
                return base.ToString();
            }
        }

        public virtual GetGraphicsResult GetGraphics(Weapon weapon, GetGraphicsResult result)
        {
            return result;
        }

        public class GetGraphicsResult
        {

        }

        public virtual GetCostResult GetCost(Weapon weapon, GetCostResult result)
        {
            return result;
        }

        public class GetCostResult
        {
            public int cost { get; private set; } = 0;

            public void AddCost(int cost)
            {
                this.cost += cost;
            }

            public void SubtractCost(int cost)
            {
                this.cost -= cost;
            }
        }

        public virtual ShouldDestroyProjectileResult ShouldDestroyProjectile(Weapon weapon, IProjectile projectile, RaycastHit2D raycastHit, ShouldDestroyProjectileResult result)
        {
            return result;
        }

        public class ShouldDestroyProjectileResult
        {
            public bool shouldDestroy = true;
        }
    }
}