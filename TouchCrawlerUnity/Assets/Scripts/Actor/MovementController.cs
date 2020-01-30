using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 destination;
    Vector2 velocity;
    Vector2 maxVelocity;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        velocity = Vector2.zero;
        destination = body.position;
        maxVelocity = new Vector2(3f, 3f);
    }

    void Update()
    {
        //Debug.Log(nextLocation);
        //Debug.Log(velocity);
        if (IsAtDestination())
        {
            velocity = Vector2.zero;
        }

        body.velocity = this.velocity;

    }
    public void Move(Vector2 nextLocation)
    {
        this.destination = nextLocation;
        Vector2 currentLocation = body.position;
        velocity = new Vector2((nextLocation.x - currentLocation.x), (nextLocation.y - currentLocation.y));
        velocity.Normalize();
        velocity.Scale(maxVelocity);
    }

    void Stop()
    {
        body.velocity = Vector2.zero;
    }
    
    private bool IsAtDestination()
    {
        bool isAtX = (Mathf.Round(body.position.x * 10) / 10.0) == (Mathf.Round(destination.x * 10) / 10.0);
        bool isAtY = (Mathf.Round(body.position.y * 10) / 10.0) == (Mathf.Round(destination.y * 10) / 10.0);
        return isAtX && isAtY;
    }

}
