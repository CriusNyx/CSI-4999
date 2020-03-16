using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraController : MonoBehaviour
{
    public GameObject objectToTrack;
    public CameraTarget target = null;

    public Vector2 GetPosition()
    {
        if (target == null)
        {
            return GetObjectPosition();
        }
        else
        {
            return GetObjectPosition();
        }
    }

    private Vector2 GetObjectPosition()
    {
        if (objectToTrack == null)
        {
            return transform.position;
        }
        else
        {
            return objectToTrack.transform.position + Vector3.down * 1f;
        }
    }
}