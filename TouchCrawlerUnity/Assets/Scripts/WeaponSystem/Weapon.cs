using Assets.Scripts.WeaponSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.WeaponSystem.WeaponComponent;
using static Assets.Scripts.Util.DecoratorUtil;
using Assets.Scripts.WeaponSystem.Components.AccuracyControllers;

namespace Assets.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        public IWeaponOwner owner
        {
            get
            {
                return gameObject.GetComponentInParent<IWeaponOwner>();
            }
        }

        public WeaponStatBlock baseStats { get; private set; }

        public Damage Damage {get; set;}

        public IEnumerable<WeaponComponent> GetAllComponents()
        {
            return gameObject.GetComponentsInChildren<WeaponComponent>();
        }

        public virtual (bool cooldownPassed, bool weaponFired, IEnumerable<IProjectile> projectiles) Fire(IWeaponTarget target)
        {
            var components = GetAllComponents();

            var requestResult = PropegateMonad(
                new FireRequestResult(),
                components,
                (x, y) => x.RequestFire(this, target, y));


            if (requestResult.fireRequestSuccessful)
            {
                FireResult fireResult = new FireResult();
                var accuracyControllerResult = PropegateMonad(
                    new ComponentSearchResult<AccuracyController>(),
                    components,
                    (x, y) => x.ComponentSearch(y));

                for (int i = 0; i < requestResult.projectileCount; i++)
                {
                    fireResult = PropegateMonad(
                        fireResult,
                        components,
                        (x, y) => x.Fire(this, target, accuracyControllerResult.value, requestResult.spawnInfo, y));
                }
                return (requestResult.fireRequestSuccessful, fireResult.success, fireResult.projectiles);
            }

            return (requestResult.fireRequestSuccessful, false, new IProjectile[0]);
        }

        public virtual IEnumerable<IProjectile> CreateProjectile(IWeaponTarget target, AccuracyController accuracyController, BulletSpawnInfo bulletSpawnInfo, int projectileNumber)
        {
            var components = GetAllComponents();
            CreateProjectileResult result = new CreateProjectileResult();

            Vector3 position;
            Quaternion rotation;
            Vector3 direction;

            if (accuracyController == null)
            {
                (position, rotation, direction) = AccuracyController.GetDefaultSpawnPosition(this, target, projectileNumber);
            }
            else
            {
                (position, rotation, direction) = accuracyController.GetSpawnPosition(this, target, projectileNumber);
            }

            result = PropegateMonad(
                result,
                components,
                (x, y) => x.CreateProjectile(this, target, position, rotation, direction, bulletSpawnInfo, y));

            return result.projectiles;
        }

        public virtual void ApplyOnHitEffects(Vector3 position, Vector3 normal, IWeaponTarget target, Damage damage) 
        {
            var components = GetAllComponents();
            this.Damage = damage;
            var result = PropegateMonad(
                new ApplyOnHitEffectsResult(),
                components,
                (x, y) => x.ApplyOnHitEffects(position, normal, this, target, y));
        }

        public virtual void ApplyOnHitEffects(Vector3 position, Vector3 normal, IWeaponTarget target) => ApplyOnHitEffects(position, normal, target, null);


        public virtual WeaponStatBlock GetStats()
        {
            var components = GetAllComponents();

            var result = PropegateMonad(
                new GetStatsResult(),
                components,
                (x, y) => x.GetStats(this, y));

            return result.block;
        }

        public virtual string GetName()
        {
            var components = GetAllComponents();

            var result = PropegateMonad(
                new GetNameResult(),
                components,
                (x, y) => x.GetName(this, y));

            return result.ToString();
        }

        public virtual void GetGraphics()
        {
            var components = GetAllComponents();

            var result = PropegateMonad(
                new GetGraphicsResult(),
                components,
                (x, y) => x.GetGraphics(this, y));

            throw new NotImplementedException("Weapon Graphics is not fully implimented");
        }

        public virtual int GetCost()
        {
            var components = GetAllComponents();

            var result = PropegateMonad(
                new GetCostResult(),
                components,
                (x, y) => x.GetCost(this, y));

            return result.cost;
        }

        public virtual bool ShouldDestroyProjectile(IProjectile projectile, Collider2D collider)
        {
            var components = GetAllComponents();

            var result = PropegateMonad(
                new ShouldDestroyProjectileResult(),
                components,
                (x, y) => x.ShouldDestroyProjectile(this, projectile, collider, y));

            return result.shouldDestroy;
        }

        [Flags]
        public enum WeaponTargetType
        {
            player = 1 << 0,
            enemy = 1 << 1,
        }
    }
}