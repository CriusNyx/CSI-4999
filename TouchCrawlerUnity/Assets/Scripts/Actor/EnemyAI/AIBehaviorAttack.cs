using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.WeaponSystem;

public class AIBehaviorAttack : MonoBehaviour
{
    Weapon weapon;
    IActor target;
    MovementController movementController;
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

    private void Attack()
    {
        target = GameObject.FindObjectOfType<PlayerActor>();
        weapon.Fire(target);
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
