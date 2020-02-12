using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
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
    public void Move(Vector2 nextLocation)
    {
        this.destination = nextLocation;
    }

    public void Move(IActor target)
    {
        destination = target.GetLocation();

    }

    public void Stop()
    {
        destination = body.position;  
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Stop();
    }

    public bool IsAtDestination()
    {
        return Vector2.Distance(body.position, destination) < 0.1f;
    }

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

    public Vector2 GetLocation()
    {
        return body.position;
    }

}
