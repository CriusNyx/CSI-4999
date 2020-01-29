using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public interface IProjectile
    {
        GameObject projectile { get; }
        Vector2 Current { get; }
        Vector2 Source { get; set; }
        Weapon WeaponSrc { get; }
        IWeaponTarget target { get; }
        Vector2 Direction { get; }

        void Initialize(Weapon weapon, IWeaponTarget target, Vector2 direction, Vector2 pos);

    }
}