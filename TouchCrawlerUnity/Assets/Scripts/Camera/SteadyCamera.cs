using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteadyCamera : MonoBehaviour
{
    public float cameraDecay = 0.1f;
    Vector2 currentPos;

    public void LateUpdate()
    {
        Vector2 targetPosition = GetComponent<BasicCameraController>().GetPosition();
        Vector2 delta = targetPosition - currentPos;
        delta = delta * MathFunctions.LogarithmicDecay(cameraDecay, Time.deltaTime);
        currentPos = currentPos + delta;

        Debug.DrawRay(currentPos, Vector3.up);
    }
}
