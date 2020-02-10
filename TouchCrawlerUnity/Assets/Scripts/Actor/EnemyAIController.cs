using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;


public class EnemyAIController : MonoBehaviour
{
    public bool isWanderer;
    public Vector2[] wanderPath;
    public int timeBeforeNextWander;
    private int timeSinceLastWander;
    private int wanderIterator;
    public float attackDistance = 3f;
    public float stopDistance = 1.5f;
    private IActor target;
    private Rigidbody2D body;
    private MovementController movementController;
    private Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        movementController = GetComponent<MovementController>();
        wanderIterator = 0;
        timeSinceLastWander = 0;
        target = GameObject.FindObjectOfType<PlayerActor>();
        weapon = GetComponentInChildren<Weapon>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isWanderer)
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

    private void Wander()
    {
        if (movementController.IsAtDestination() && timeSinceLastWander++ >= timeBeforeNextWander)
        {
            movementController.Move(NextWanderLocation());
            timeSinceLastWander = 0;
        }
    }

    private void Attack()
    {
        weapon.Fire(target);
    }

    private Vector2 NextWanderLocation()
    {
        Vector2 nextLocation = wanderPath[wanderIterator++];
        if(wanderIterator >= wanderPath.Length)
        {
            wanderIterator = 0;
        }
        return nextLocation;
    }

    private bool IsCloseEnoughToAttack()
    {
        Vector2 distance = movementController.DistanceToDestination();
        return System.Math.Abs(distance.x) <= 3f && System.Math.Abs(distance.y) <= 3f;
    }

    private bool IsCloseEnoughToStop()
    {
        Vector2 distance = movementController.DistanceToDestination();
        return System.Math.Abs(distance.x) <= 1.5f && System.Math.Abs(distance.y) <= 1.5f;
    }

    public void StartAttacking()
    {
        isWanderer = false;
    }
}
