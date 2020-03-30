using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Events;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using UnityEngine;
using static StatsController;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(StatsController))]
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(HealthController))]
[RequireComponent(typeof(StatsController))]
public class DefaultActor : MonoBehaviour, IActor, IEventListener, IWeaponOwner
{

    public MonoBehaviour monoBehaviour
    {
        get => this;
    }

    public int actorLevel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public IActor target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public IActor attacker
    {
        get;
        private set;
    }

    public Weapon weapon {
        get { return gameObject.GetComponentInChildren<Weapon>(); }
        //private set;
    }

    public MovementController movementController
    {
        get;
        private set;
    }

    public StatsController statsController { get; private set; }

    public HealthController healthController { get; private set; }

    public virtual Weapon.WeaponTargetType AttackWeaponTargetType { get => attackWeaponTargetType; set => attackWeaponTargetType = value; }

    public Weapon.WeaponTargetType attackWeaponTargetType;

    public virtual Weapon.WeaponTargetType DefenseWeaponTargetType { get => defenseWeaponTargetType; set => defenseWeaponTargetType = value; }

    public Weapon.WeaponTargetType defenseWeaponTargetType;

    public IActor actor => this;

    public Inventory inventory { get; private set; }

    public bool wasAttacked
    {
        get;
        private set;
    }

    public void Awake()
    {
        movementController = GetComponent<MovementController>();
        //weapon = GetComponentInChildren<Weapon>();
        inventory = gameObject.GetComponent<Inventory>();
        healthController = GetComponent<HealthController>();
        statsController = GetComponent<StatsController>();
        wasAttacked = false;
        
        if (IsPlayer())
        {
            EventSystem.AddEventListener(EventSystem.EventChannel.player, EventSystem.EventSubChannel.input, this);
            EventSystem.AddEventListener(EventSystem.EventChannel.inventory, EventSystem.EventSubChannel.item, this);
        }
    }

    public void Start()
    {
        ProtectedStart();
    }

    protected virtual void ProtectedStart()
    {

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
            Debug.Log("PickUpItem: " + item.name);
            inventory.Add(item);
        }
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
        
        //Debug.Log(damage.ToString());
        //attacker = damage.weaponOwner;

        //TODO: modify damage based on stats

        Stat spellResistance = statsController.GetStat(StatType.SpellResistance);
        Stat physicalResistance = statsController.GetStat(StatType.DamageResistance);

        if (damage is SpellDamage) {
            damage.amount -= spellResistance.CalculateStatValue() * 0.1f;
            healthController.TakeDamage(damage);
        }
        if (damage is PhysicalDamage){
            damage.amount -= physicalResistance.CalculateStatValue() * 0.1f;
            healthController.TakeDamage(damage);
        }
        if (damage is FlatDamage){
            healthController.TakeDamage(damage);
        }

        //healthController.TakeDamage(damage);
        //Debug.Log(this + ": Attacked");
        //Debug.Log(damage.ToString());
        wasAttacked = true;

        return true;
    }

    public virtual void OnRoomEnter(RoomController roomController)
    {

    }

    public virtual void OnRoomExit(RoomController roomController)
    {

    }
}
