using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour, ICameraTarget
{
    public Vector2 scale = new Vector2(0.75f, 0.5f);
    public Vector2 maxDistance = new Vector2(1.5f, 1f);

    public Vector2 GetTarget(Vector2 trackedObjectPosition)
    {
        Vector2 center = transform.position;
        Vector2 delta = trackedObjectPosition - center;
        delta.Scale(scale);
        delta.x = Mathf.Clamp(delta.x, -maxDistance.x, maxDistance.x);
        delta.y = Mathf.Clamp(delta.y, -maxDistance.y, maxDistance.y);
        return center + delta;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, maxDistance * 2f);

        Vector2 cameraBounds = maxDistance;
        Vector2 tempScale = scale;
        tempScale.x = 1 / tempScale.x;
        tempScale.y = 1 / tempScale.y;
        cameraBounds.Scale(tempScale);

        Gizmos.DrawWireCube(transform.position, cameraBounds * 2f);
    }    
}