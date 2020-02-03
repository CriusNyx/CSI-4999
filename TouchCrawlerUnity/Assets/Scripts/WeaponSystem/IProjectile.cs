﻿using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public interface IProjectile
    {
        GameObject gameObject { get; }
        Vector2 Current { get; }
        Vector2 Source { get; }
        Weapon WeaponSrc { get; }
        IWeaponTarget target { get; }

        void Initialize(Weapon weapon, IWeaponTarget target, Vector2 velocity, Vector2 pos);

    }
}