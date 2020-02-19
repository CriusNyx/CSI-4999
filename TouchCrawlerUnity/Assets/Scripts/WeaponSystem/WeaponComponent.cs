using Assets.Scripts.WeaponSystem.Components.AccuracyControllers;
using Assets.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public abstract class WeaponComponent : MonoBehaviour
    {
        public abstract ComponentType componentType { get; }

        public enum ComponentType
        {
            AccuracyController,
            Trigger,
            Cooldown,
            ProjectileFactory,
            Debug,
            OnHitEffect,
            ProjectileDefinition,
            None
        }

        #region Methods
        public virtual FireRequestResult RequestFire(Weapon weapon, IWeaponTarget target, FireRequestResult result)
        {
            return result;
        }

        public virtual FireResult Fire(Weapon weapon, IWeaponTarget target, AccuracyController accuracyController, BulletSpawnInfo bulletSpawnInfo, FireResult result)
        {
            return result;
        }

        public virtual CreateProjectileResult CreateProjectile(Weapon weapon, IWeaponTarget target, Vector3 position, Quaternion rotation, Vector3 direction, BulletSpawnInfo bulletSpawnInfo, CreateProjectileResult result)
        {
            return result;
        }

        public virtual ApplyOnHitEffectsResult ApplyOnHitEffects(Weapon weapon, IWeaponTarget target, ApplyOnHitEffectsResult result)
        {
            return result;
        }

        public virtual GetStatsResult GetStats(Weapon weapon, GetStatsResult result)
        {
            return result;
        }

        public virtual GetNameResult GetName(Weapon weapon, GetNameResult result)
        {
            return result;
        }

        public virtual GetGraphicsResult GetGraphics(Weapon weapon, GetGraphicsResult result)
        {
            return result;
        }

        public virtual GetCostResult GetCost(Weapon weapon, GetCostResult result)
        {
            return result;
        }

        public virtual ShouldDestroyProjectileResult ShouldDestroyProjectile(Weapon weapon, IProjectile projectile, Collider2D collider, ShouldDestroyProjectileResult result)
        {
            return result;
        }

        public ComponentSearchResult<T> ComponentSearch<T>(ComponentSearchResult<T> result) where T : WeaponComponent
        {
            if (this is T t)
            {
                result.value = t;
            }
            return result;
        }

        public ComponentSetSearchResult<T> ComponentSetSearch<T>(ComponentSetSearchResult<T> result) where T : WeaponComponent
        {
            if (this is T t)
            {
                result.AddComponent(t);
            }
            return result;
        }
        #endregion

        #region Result Classes
        public class FireRequestResult
        {
            public bool fireRequestSuccessful = false;
            public int projectileCount { get; private set; } = 0;
            public readonly BulletSpawnInfo spawnInfo = new BulletSpawnInfo();

            public void AddProjectile(int count)
            {
                projectileCount += count;
            }

            public void RemoveProjectile(int count)
            {
                projectileCount -= count;
            }
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

        public class CreateProjectileResult
        {
            public IEnumerable<IProjectile> projectiles => projectileList;
            private List<IProjectile> projectileList = new List<IProjectile>();

            public void Add(IProjectile projectile) => projectileList.Add(projectile);
        }

        public class ApplyOnHitEffectsResult
        {
            public bool applyEffects = false;
        }

        public class GetStatsResult
        {
            public WeaponStatBlock block = new WeaponStatBlock();
        }

        public class GetNameResult
        {
            public override string ToString()
            {
                return base.ToString();
            }
        }

        public class GetGraphicsResult
        {

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

        public class ShouldDestroyProjectileResult
        {
            public bool shouldDestroy = true;
        }

        public class ComponentSearchResult<T> where T : WeaponComponent
        {
            public T value;
        }

        public class ComponentSetSearchResult<T> where T : WeaponComponent
        {
            private List<T> list = new List<T>();
            public IEnumerable<T> set => list;

            public void AddComponent(T t) => list.Add(t);
        }

        public class BulletSpawnInfo
        {
            public Color? color;
            public GameObject prefabToSpawn;
            public float speedModifier { get; private set; } = 1f;

            public void AddSpeedModRatio(float speed)
            {
                speedModifier *= speed;
            }
        }
        #endregion
    }
}