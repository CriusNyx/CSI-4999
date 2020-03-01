using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Events;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(StatsController))]
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(HealthController))]
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

    public HealthController healthController { get; private set; }

    public virtual Weapon.WeaponTargetType AttackWeaponTargetType { get => attackWeaponTargetType; set => attackWeaponTargetType = value; }

    public Weapon.WeaponTargetType attackWeaponTargetType;

    public virtual Weapon.WeaponTargetType DefenseWeaponTargetType { get => defenseWeaponTargetType; set => defenseWeaponTargetType = value; }

    public Weapon.WeaponTargetType defenseWeaponTargetType;

    public IActor actor => this;

    public Inventory inventory { get; private set; }

    public void Awake()
    {
        movementController = GetComponent<MovementController>();
        weapon = GetComponentInChildren<Weapon>();
        inventory = gameObject.GetComponent<Inventory>();
        healthController = GetComponent<HealthController>();
        if (IsPlayer())
        {
            EventSystem.AddEventListener(EventSystem.EventChannel.player, EventSystem.EventSubChannel.input, this);
            EventSystem.AddEventListener(EventSystem.EventChannel.inventory, EventSystem.EventSubChannel.item, this);
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

    // Returns the location of the actor
    public Vector2 GetLocation()
    {
        return movementController.GetLocation();
    }
    
    // Picks up the item if inventory is not full
    public void PickUpItem(Item item)
    {
        if (inventory.IsFull)
        {
            Debug.Log("Inventory is full! Cannot pick up: " + item.name);
        }
        else
        {
            inventory.Add(item);
        }

        Debug.Log("PickUpItem: " + item.name);
    }

    // Passes down the distance to destination from movement controller
    public Vector2 DistanceToDestination()
    {
        return movementController.DistanceToDestination();
    }

    // Not implemented yet
    public void UseItem(Item item)
    {
        throw new System.NotImplementedException();
    }

    public virtual void AcceptEvent(IEvent e)
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
        // Temporarily commented out
        /*if (e is PickupItemTouchedEvent pickupItemTouchedEvent)
        {
            Debug.Log("Pick up item");
        }
        if (e is DropItemEvent dropItemEvent)
        {
            Debug.Log("Drop item");
        }*/
    }

    public bool DoDamage(Damage damage)
    {
        healthController.TakeDamage(damage);
        //Debug.Log(damage.ToString());
        //attacker = damage.weaponOwner;
        return true;
    }
}
