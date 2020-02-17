using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Events;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(StatsController))]
public class DefaultActor : MonoBehaviour, IActor, IEventListener, IWeaponOwner
{

    public int actorLevel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public IActor target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public IActor attacker
    {
        get;
        private set;
    }

    public Weapon weapon { 
        get; 
        private set;
    }

    public MovementController movementController
    {
        get;
        private set;
    }

    public virtual Weapon.WeaponTargetType AttackWeaponTargetType { get => attackWeaponTargetType; set => attackWeaponTargetType = value; }

    public Weapon.WeaponTargetType attackWeaponTargetType;

    public virtual Weapon.WeaponTargetType DefenseWeaponTargetType { get => defenseWeaponTargetType; set => defenseWeaponTargetType = value; }

    public Weapon.WeaponTargetType defenseWeaponTargetType;

    public IActor actor => this;

    public void Start()
    {
        movementController = GetComponent<MovementController>();
        weapon = GetComponentInChildren<Weapon>();
        if (IsPlayer())
        {
            EventSystem.AddEventListener(EventSystem.EventChannel.player, EventSystem.EventSubChannel.input, this);
        }
    }
    public bool IsPlayer()
    {
        if (this is PlayerActor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Returns the location of the actor
    /// </summary>
    /// <returns>Returns the location of the actor</returns>
    public Vector2 GetLocation()
    {
        return movementController.GetLocation();
    }
    
    /// <summary>
    /// Not implemented yet
    /// </summary>
    /// <param name="item"></param>
    public void PickUpItem(object item)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Passes down the distance to destination from movement controller
    /// </summary>
    /// <returns>The distance between the actor and its destination</returns>
    public Vector2 DistanceToDestination()
    {
        return movementController.DistanceToDestination();
    }

    /// <summary>
    /// Not implemented yet
    /// </summary>
    /// <param name="item"></param>
    public void UseItem(object item)
    {
        throw new System.NotImplementedException();
    }

    public void AcceptEvent(IEvent e)
    {
        if (e is MoveInputEvent moveInputEvent)
        {
            Vector2 nextLocation = moveInputEvent.ray.origin;
            movementController.Move(nextLocation);
        }
        if (e is AttackInputEvent attackInputEvent)
        {
            this.weapon?.Fire(attackInputEvent.attackable.GetTarget());
        }
    }

    public bool DoDamage(Damage damage)
    {
        throw new System.NotImplementedException();
        //Debug.Log(damage.ToString());
        //attacker = damage.weaponOwner;
        return true;
    }
}
