using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour, ITouchable
{
    public IEvent GetEvent()
    {
        return new AttackInputEvent(this);
    }
}
