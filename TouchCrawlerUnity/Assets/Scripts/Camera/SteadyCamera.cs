using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteadyCamera : MonoBehaviour
{
    public float cameraDecay = 0.1f;
    Vector2 currentPos;
    //public Vector2 targetPosition;

    public void LateUpdate()
    {
        Vector2 targetPosition = GetComponent<BasicCameraController>().GetPosition();
        Vector2 delta = targetPosition - currentPos;
        delta = delta * MathFunctions.LogarithmicDecay(cameraDecay, Time.deltaTime);
        currentPos = currentPos + delta;

        Vector3 position = currentPos;
        position.z = transform.position.z;

        transform.position = position;

        Debug.DrawRay(currentPos, Vector3.up);
    }
}