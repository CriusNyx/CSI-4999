using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public interface IWeaponOwner
    {
        GameObject gameObject { get; }
    }
}