using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{
    // Components
    Rigidbody2D body;
    new BoxCollider2D collider;

    // Velocity variables
    Vector2 destination;
    public Vector2 velocity;
    public Vector2 maxVelocity = new Vector2(3f, 3f);

    void Start()
    {
        // Initialize all components;
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        velocity = Vector2.zero;
        destination = body.position;
    }

    void FixedUpdate()
    {
        if (IsAtDestination())
        {
            Stop();
        }

        var delta = (destination - body.position);
        velocity = delta.normalized;
        velocity.Scale(maxVelocity);
        var velocityPerFrame = velocity * Time.fixedDeltaTime;
        if(delta.magnitude < velocityPerFrame.magnitude)
        {
            body.velocity = delta / Time.fixedDeltaTime;
        }
        else
        {
            body.velocity = velocity;
        }
    }

    // Sets the destination of the actor to the Vector2
    public void Move(Vector2 nextLocation)
    {
        this.destination = nextLocation;
    }

    // Sets the destination of the actor to the position of an actor
    public void Move(IActor target)
    {
        destination = target.GetLocation();

    }

    // Stops the actor
    public void Stop()
    {
        destination = transform.position;  
    }

    // Will stop on a collision
    public void Warp(Vector3 newLoc)
    {
        transform.position = newLoc;
        Stop();
    }

    /// <summary>
    /// Will stop on a collision
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        Stop();
    }

    // Tests if the actor is at the destination yet
    public bool IsAtDestination()
    {
        return Vector2.Distance(body.position, destination) < 0.1f;
    }

    // Returns the distance to the actors destination
    public Vector2 DistanceToDestination()
    {
        if (destination != null)
        {
            return destination - body.position;
        }
        else
        {
            return Vector2.zero;
        }
    }

    // Returns the location the actor
    public Vector2 GetLocation()
    {
        return body.position;
    }
}
