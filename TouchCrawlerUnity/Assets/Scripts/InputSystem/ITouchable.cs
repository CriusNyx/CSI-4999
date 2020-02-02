using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Events;

public interface ITouchable
{
    IEvent GetEvent();
}
