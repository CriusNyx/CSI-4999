using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public interface IWeaponTarget
    {
        GameObject gameObject { get; }

        IActor actor { get; }

        /// <summary>
        /// Returns true if the damage object is accepted
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        bool DoDamage(Damage damage);
    }

    public static class IWeaponTargetExtensions
    {
        public static bool ValidateTarget(this IWeaponTarget target, Weapon.WeaponTargetType attackType)
        {
            try
            {
                return (target.actor.DefenseWeaponTargetType & attackType) != 0;
            }
            catch
            {
                return false;
            }
        }
    }
}