using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    public float timeToLive = 1f;
    private float destroyTime = -1f;

    private void Start()
    {
        destroyTime = Time.time + timeToLive;
    }

    private void Update()
    {
        if(Time.time > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}