using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D body
    {
        get;
    }
    Vector2 nextLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Move(Vector2 nextLocation)
    {
        this.nextLocation = nextLocation;
    }

    void Stop()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
