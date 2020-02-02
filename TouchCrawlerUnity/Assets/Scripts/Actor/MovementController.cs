using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D body;
    BoxCollider2D collider;
    Vector2 destination;
    Vector2 velocity;
    public Vector2 maxVelocity;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        velocity = Vector2.zero;
        destination = body.position;
        maxVelocity = new Vector2(3f, 3f);
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

    void Stop()
    {
        destination = body.position;
      
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected");
        Stop();
    }

    private bool IsAtDestination()
    {
        bool isAtX = (Mathf.Round(body.position.x * 5) / 5.0) == (Mathf.Round(destination.x * 5) / 5.0);
        bool isAtY = (Mathf.Round(body.position.y * 5) / 5.0) == (Mathf.Round(destination.y * 5) / 5.0);
        return isAtX && isAtY;
    }

}
