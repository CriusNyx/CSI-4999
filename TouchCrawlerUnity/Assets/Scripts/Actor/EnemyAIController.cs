using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;


public class EnemyAIController : MonoBehaviour
{
    //Behavior variables
    public bool isPatrolling;
    public bool isWandering;
    public Vector2[] patrolPath;
    public int stopDuration;
    private int stopTime;
    public float attackDistance = 3f;
    public float stopDistance = 1.5f;

    //Actor components
    private IActor target;
    private NPCActor npcActor;
    private Rigidbody2D body;
    private MovementController movementController;
    private Weapon weapon;

    void Start()
    {
        movementController = GetComponent<MovementController>();
        stopTime = 0;
        target = GameObject.FindObjectOfType<PlayerActor>();
        weapon = GetComponentInChildren<Weapon>();
        body = GetComponent<Rigidbody2D>();
        npcActor = GetComponent<NPCActor>();
        if (patrolPath == null)
        {
            patrolPath = new Vector2[] { body.position } ;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (WasAttackedYet())
        {
            StartAttacking();
        }

        if (isPatrolling)
        {
            Patrol();
        }else if (isWandering)
        {
            Wander();
        }
        else
        {
            movementController.Move(target);
            if (IsCloseEnoughToStop())
            {
                movementController.Stop();
            }
            if (IsCloseEnoughToAttack())
            {
                this.Attack();
            }
           
        }
    }

    /// <summary>
    /// This moves the enemy in loop along the points in the patrolPath array
    /// </summary>
    private void Patrol()
    {
        if ((movementController.IsAtDestination() || body.velocity == Vector2.zero) && stopTime++ >= stopDuration)
        {
            movementController.Move(NextWanderLocation());
            stopTime = 0;
        }
    }

    private void Wander()
    {
        if ((movementController.IsAtDestination() || body.velocity == Vector2.zero) && stopTime++ >= stopDuration)
        {
            int lowerLimitX = (int)body.position.x - 3;
            int upperLimitX = (int)body.position.x + 3;
            int lowerLimitY = (int)body.position.y - 3;
            int upperLimitY = (int)body.position.y + 3;
            var random = new System.Random();
            int nextX = random.Next(lowerLimitX, upperLimitX);
            int nextY = random.Next(lowerLimitY, upperLimitY);
            movementController.Move(new Vector2((float)nextX, (float)nextY));
            stopTime = 0;
        }
        
    }

    private void Attack()
    {
        weapon.Fire(target);
    }

    private Vector2 NextWanderLocation()
    {
        Vector2 nextLocation = patrolPath[stopTime++];
        if(stopTime >= patrolPath.Length)
        {
            stopTime = 0;
        }
        return nextLocation;
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

    private bool WasAttackedYet()
    {
        return npcActor.attacker != null;
    }

    private void StartAttacking()
    {
        isPatrolling = false;
        isWandering = false;
    }
}
