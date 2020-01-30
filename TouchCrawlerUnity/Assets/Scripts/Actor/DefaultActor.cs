using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Events;
using UnityEngine;

public class DefaultActor : MonoBehaviour, IActor, IEventListener
{
    public int actorLevel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public IActor target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public MovementController movementController
    {
        get;
        private set;
    }

    public void Start()
    {
        movementController = GetComponent<MovementController>();
        EventSystem.AddEventListener(EventSystem.EventChannel.player, EventSystem.EventSubChannel.input, this);
        
    }
    public bool IsPlayer()
    {
        if(this is PlayerActor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PickUpItem(object item)
    {
        throw new System.NotImplementedException();
    }

    public void UseItem(object item)
    {
        throw new System.NotImplementedException();
    }

    public void AcceptEvent(IEvent e)
    { 
        if (IsPlayer()) {
            if (e is MoveInputEvent mie)
            {
                Vector2 nextLocation = (Vector2) mie.ray.origin;
                movementController.Move(nextLocation);
            }
            if (e is AttackInputEvent aie)
            {
                //TODO
            }
        }
    }
}
