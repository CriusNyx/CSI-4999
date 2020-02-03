using Assets.Scripts.Events;
using Assets.Scripts.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour, ITouchable
{
    public IEvent GetEvent()
    {
        return new AttackInputEvent(this);
    }

    public IWeaponTarget GetTarget()
    {
        return gameObject.GetComponent<IWeaponTarget>();
    }
}
