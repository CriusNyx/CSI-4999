using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.WeaponSystem;
using Assets.Scripts.Actor.EnemyAI;

public class AIBehaviorAttack : AIBehaviour
{
    Weapon weapon;
    public IActor target
    {
        get;
        private set;
    }

    public override float RandomWeight => 1f;

    public override float ExecutionTime => 1f;

    public bool hasTarget = true;
    MovementController movementController;
    public bool manual = false;
    public float attackDistance = 3f;
    public float stopDistance = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
        movementController = GetComponent<MovementController>();
        target = GameObject.FindObjectOfType<PlayerActor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (manual)
        {
            ManualAttack();
        }
        else
        {
            AutomaticAttack();
        }
    }

    private bool Attack()
    {
        target = GameObject.FindObjectOfType<PlayerActor>();
        hasTarget = target != null;
        Debug.Log(target);
        return weapon.Fire(target).weaponFired;
    }
    private void AutomaticAttack()
    {
        if (!Attack())
        {
            movementController.Move(target);
        }
    }
    private void ManualAttack()
    {
        if (IsCloseEnoughToAttack())
        {
            Attack();
        }
        if (IsCloseEnoughToStop())
        {
            movementController.Stop();
        }
        else
        {
            movementController.Move(target);
        }
    }

    private bool IsCloseEnoughToAttack()
    {
        Vector2 distance = movementController.DistanceToDestination();
        return System.Math.Abs(distance.x) <= attackDistance && System.Math.Abs(distance.y) <= attackDistance;
    }

    private bool IsCloseEnoughToStop()
    {
        Vector2 distance = movementController.DistanceToDestination();
        return System.Math.Abs(distance.x) <= stopDistance && System.Math.Abs(distance.y) <= stopDistance;
    }
}
