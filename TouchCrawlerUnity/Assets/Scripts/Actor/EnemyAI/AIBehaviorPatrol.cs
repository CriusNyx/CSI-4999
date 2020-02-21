using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviorPatrol : MonoBehaviour
{
    public Vector2[] patrolPath;
    int patrolIterator;
    MovementController movementController;
    public int stopDuration = 10;
    private int stopTime;

    void Start()
    {
        patrolIterator = 0;
        stopTime = 0;
        if (patrolPath == null)
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
