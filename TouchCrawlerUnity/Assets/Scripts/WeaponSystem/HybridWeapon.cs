using Assets.Scripts.Util;
using Assets.Scripts.WeaponSystem.Components;
using Assets.Scripts.WeaponSystem.Components.AccuracyControllers;
using Assets.WeaponSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.WeaponSystem.WeaponComponent;

namespace Assets.Scripts.WeaponSystem
{
    public class HybridWeapon : Weapon
    {
        public override void ApplyOnHitEffects(Vector3 position, Vector3 normal, IWeaponTarget target)
        {
            //do nothing
        }

        public override IEnumerable<IProjectile> CreateProjectile(IWeaponTarget target, AccuracyController accuracyController, BulletSpawnInfo bulletSpawnInfo, int projectileNumber)
        {
            //do nothing
            return new IProjectile[] { };
        }

        public override (bool cooldownPassed, bool weaponFired, IEnumerable<IProjectile> projectiles) Fire(IWeaponTarget target)
        {
            Validate();
            bool cooldownPassed = false;
            bool weaponFired = false;
            List<IProjectile> output = new List<IProjectile>();
            foreach (Weapon weapon in GetSubWeapons())
            {
                (bool subCooldown, bool subFire, IEnumerable<IProjectile> subProjectiles) = weapon.Fire(target);
                cooldownPassed = cooldownPassed || subCooldown;
                weaponFired = weaponFired || subFire;
                output.AddRange(subProjectiles);
            }
            return (cooldownPassed, weaponFired, output);
        }

        public override int GetCost()
        {
            return base.GetCost();
        }

        public override void GetGraphics()
        {
            base.GetGraphics();
        }

        public override string GetName()
        {
            string output = "";
            foreach(var weapon in GetSubWeapons())
            {
                output += weapon.GetName() + " + ";
            }
            output = output.TrimEnd(' ', '+');
            return output;
        }

        public override WeaponStatBlock GetStats()
        {
            return base.GetStats();
        }

        public override bool ShouldDestroyProjectile(IProjectile projectile, Collider2D collider)
        {
            return base.ShouldDestroyProjectile(projectile, collider);
        }

        private IEnumerable<Weapon> GetSubWeapons()
        {
            foreach (var weapon in gameObject.GetComponentsInChildren<Weapon>())
            {
                if (weapon != this)
                    yield return weapon;
            }
        }

        private void Validate()
        {
            foreach(var weapon in GetSubWeapons())
            {
                SubWeaponOnHitEffect subOnHitEffect = weapon.gameObject.EnsureComponent<SubWeaponOnHitEffect>();
                subOnHitEffect.parent = this;
            }
        }
    }
}
