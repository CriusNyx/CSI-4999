using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{
    //Components
    Rigidbody2D body;
    new BoxCollider2D collider;

    //Velocity variables
    Vector2 destination;
    public Vector2 velocity;
    public Vector2 maxVelocity = new Vector2(3f, 3f);

    void Start()
    {
        //Initialize all components;
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

    /// <summary>
    /// Sets the destination of the actor to the Vector2
    /// </summary>
    /// <param name="nextLocation">The desitination of the actor</param>
    public void Move(Vector2 nextLocation)
    {
        this.destination = nextLocation;
    }

    /// <summary>
    /// Sets the destination of the actor to the position of an actor
    /// </summary>
    /// <param name="target">The actor this actor will move towards</param>
    public void Move(IActor target)
    {
        destination = target.GetLocation();

    }

    /// <summary>
    /// Stops the actor
    /// </summary>
    public void Stop()
    {
        destination = body.position;  
    }

    public void Warp(Vector3 newLoc)
    {
        transform.position = newLoc;
    }

    /// <summary>
    /// Will stop on a collision
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        Stop();
    }

    /// <summary>
    /// Tests if the actor is at the destination yet
    /// </summary>
    /// <returns>True if it is at it's destination otherwise false</returns>
    public bool IsAtDestination()
    {
        return Vector2.Distance(body.position, destination) < 0.1f;
    }

    /// <summary>
    /// Returns the distance to the actors destination
    /// </summary>
    /// <returns>A Vector2 for the distance between the actor and the destination</returns>

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

    /// <summary>
    /// Returns the location the actor
    /// </summary>
    /// <returns>A Vector2 for the location of the actor</returns>
    public Vector2 GetLocation()
    {
        return body.position;
    }

}
