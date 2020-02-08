using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    public bool isWanderer;
    public Vector2[] wanderPath;
    public int timeBeforeNextWander;
    private int timeSinceLastWander;
    private int wanderIterator;
    private IActor target;
    private MovementController movementController;
    // Start is called before the first frame update
    void Start()
    {
        movementController = GetComponent<MovementController>();
        wanderIterator = 0;
        timeSinceLastWander = 0;
        target = GameObject.FindObjectOfType<PlayerActor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWanderer)
        {
            Wander();
        }
        else
        {
            movementController.Move(target);
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

    private Vector2 NextWanderLocation()
    {
        Vector2 nextLocation = wanderPath[wanderIterator++];
        if(wanderIterator >= wanderPath.Length)
        {
            wanderIterator = 0;
        }
        return nextLocation;
    }
}
