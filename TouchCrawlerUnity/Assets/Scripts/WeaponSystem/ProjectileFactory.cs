using Assets.Scripts.Util;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : WeaponComponent
{
    public override ComponentType componentType => ComponentType.ProjectileFactory;

    //public GameObject prefab;

    public override CreateProjectileResult CreateProjectile(Weapon weapon, IWeaponTarget target, Vector3 position, Quaternion rotation, Vector3 direction, BulletSpawnInfo spawnInfo, CreateProjectileResult result)
    {
        var instance = GameObjectFactory.Instantiate(spawnInfo.prefabToSpawn, position, rotation);
        var projectile = instance.GetComponent<IProjectile>();

        if(projectile != null)
        {
            Vector2 velocity = target.gameObject.transform.position - weapon.gameObject.transform.position;
            var owner = weapon.owner;
            var actor = owner.actor;
            var targetType = actor.AttackWeaponTargetType;
            projectile.Initialize(weapon, target, direction, position, spawnInfo.color, spawnInfo.speedModifier, weapon.owner.actor.AttackWeaponTargetType);
            result.Add(projectile);
        }

        return result;
    }
}
