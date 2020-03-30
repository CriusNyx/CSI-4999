using Assets.Scripts.Actor.EnemyAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviorWander : AIBehaviour
{
    Rigidbody2D body;
    MovementController movementController;
    Vector2 nextWander;
    public int stopDuration = 10;
    private int stopTime;

    public override float RandomWeight => 2f;

    public override float ExecutionTime => 5f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        movementController = GetComponent<MovementController>();
        nextWander = body.position;
        stopTime = 0;
    }

    void FixedUpdate()
    {
        if (movementController.IsAtDestination() && stopTime++ >= stopDuration)
        {
            movementController.Move(getNextWanderLocation());
            stopTime = 0;
        }
    }

    // Update is called once per frame
    Vector2 getNextWanderLocation()
    {
        int lowerLimitX = (int)body.position.x - 3;
        int upperLimitX = (int)body.position.x + 3;
        int lowerLimitY = (int)body.position.y - 3;
        int upperLimitY = (int)body.position.y + 3;
        var random = new System.Random();
        int nextX = random.Next(lowerLimitX, upperLimitX);
        int nextY = random.Next(lowerLimitY, upperLimitY);
        return new Vector2((float)nextX, (float)nextY);
    }
}
