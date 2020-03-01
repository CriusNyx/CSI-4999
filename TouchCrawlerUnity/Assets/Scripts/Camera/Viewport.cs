using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewport : MonoBehaviour
{
    public static Viewport Instance { get; private set; }
    public SteadyCamera SteadyCam { get; private set; }
    public BasicCameraController CameraController { get; private set; }

    private void Awake()
    {
        Instance = this;
        SteadyCam = gameObject.GetComponent<SteadyCamera>();
        CameraController = gameObject.GetComponent<BasicCameraController>();
    }
}