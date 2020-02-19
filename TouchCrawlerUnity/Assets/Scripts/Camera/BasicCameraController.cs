using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraController : MonoBehaviour
{
    public CameraTarget target = null;

    public Vector2 GetPosition()
    {
        if(target == null)
        {
            return transform.position;
        }
        else
        {
            return target.GetTarget(transform.position);
        }
    }
}