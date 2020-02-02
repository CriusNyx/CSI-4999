using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public interface IDamageSource
    {
        float CalculateDamage(IWeaponOwner weaponOwner, IWeaponTarget weaponTarget, IProjectile projectile);
    }
}