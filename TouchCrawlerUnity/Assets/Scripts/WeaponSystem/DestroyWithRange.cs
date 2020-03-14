using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithRange : MonoBehaviour
{
    public Vector2 spawnPosition;
    public float range = -1f;

    public void Update()
    {
        if(range >= 0f && Vector2.Distance(spawnPosition, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }
}