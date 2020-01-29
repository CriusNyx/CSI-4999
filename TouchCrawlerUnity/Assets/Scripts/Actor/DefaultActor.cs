using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultActor : MonoBehaviour, IActor
{
    public int actorLevel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public IActor target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public MovementController movementController => throw new System.NotImplementedException();

    public bool IsPlayer()
    {
        throw new System.NotImplementedException();
    }

    public void PickUpItem(object item)
    {
        throw new System.NotImplementedException();
    }

    public void UseItem(object item)
    {
        throw new System.NotImplementedException();
    }
}
