using Assets.Scripts.Actor.EnemyAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviorPatrol : AIBehaviour
{
    public Vector2[] patrolPath;
    int patrolIterator;
    MovementController movementController;
    public int stopDuration = 10;
    private int stopTime;

    public override float RandomWeight => 1f;

    public override float ExecutionTime => 10f;

    void Start()
    {
        patrolIterator = 0;
        stopTime = 0;
        if (patrolPath.Length == 0)
        {
            patrolPath = new Vector2[] { GetComponent<Rigidbody2D>().position };
        }

        movementController = GetComponent<MovementController>();
    }

    void FixedUpdate()
    {
        if (movementController.IsAtDestination() && stopTime++ >= stopDuration)
        {
            movementController.Move(getNextPatrolLocation());
            stopTime = 0;
        }
    }

    public Vector2 getNextPatrolLocation()
    {
        Vector2 nextLocation = patrolPath[patrolIterator++];
        if (patrolIterator >= patrolPath.Length)
        {
            patrolIterator = 0;
        }
        return nextLocation;
    }

}