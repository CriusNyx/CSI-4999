using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour, IEventListener
{
    public Camera mainCamera;
    // Length of shake effect
    public float shakeTime = 0.5f;
    // Magntiude of shake effect
    [Range(0f, 1f)]
    public float shakeMagnitude = 0.4f;

    private void Start()
    {
        EventSystem.AddEventListener(EventSystem.EventChannel.player, EventSystem.EventSubChannel.screenShake, this);
    }

    public static void StartShake(float trauma, float length)
    {
        EventSystem.Broadcast(EventSystem.EventChannel.player, EventSystem.EventSubChannel.screenShake, new ScreenShakeEvent(trauma, length));
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.T))
        //{
        //    StartCoroutine(Shake(shakeMagnitude, shakeTime));
        //}
    }

    void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    public IEnumerator Shake(float trauma, float length)
    {
        //this.shakeTime = length;

        // Store normal position + rotation before we start shaking
        Vector3 originalPosition = transform.localPosition;
        Quaternion originalRotation = transform.localRotation;

        float elapsed = 0.0f;

        if (trauma > 0)
        {
            while (elapsed < length)
            {
                // Camera Shake = trauma^2
                // Shake Angle = maxAngle * trauma * RandomFloatFromNegOneToOne
                // OffsetX = maxOffset * trauma * RandomFloatFromNegOneToOne
                // OffsetY = maxOffset * trauma * RandomFloatFromNegOneToOne

                float offsetXYZ = Random.Range(-1f, 1f) * trauma;
                float cameraShake = Mathf.Pow(trauma, 2);
                
                // Note: The recurring number 25 is the "frequency" of the Perlin Noise
                // Many things can be turned into component variables, but I left it out for simplicity's sake -Sam
                transform.localPosition = new Vector3(
                    (Mathf.PerlinNoise(offsetXYZ, Time.time * 25) * 2 - 1),
                    (Mathf.PerlinNoise(offsetXYZ + 1, Time.time * 25) * 2 - 1),
                    (Mathf.PerlinNoise(offsetXYZ + 2, Time.time * 25) * 2 - 1)) * cameraShake;

                transform.localRotation = Quaternion.Euler(new Vector3(0, 0,
                    (Mathf.PerlinNoise(offsetXYZ + 5, Time.time * 25) * 2 - 1)) * cameraShake);

                elapsed += Time.deltaTime;
                
                yield return null;
            }

            // Go back to normal position + rotation
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            yield return null;
        }
    }

    public void AcceptEvent(IEvent e)
    {
        if(e is ScreenShakeEvent sse)
        {
            StartCoroutine(Shake(sse.trama, sse.length));
        }
    }
}

public class ScreenShakeEvent : IEvent
{
    public readonly float trama, length;

    public ScreenShakeEvent(float trama, float length)
    {
        this.trama = trama;
        this.length = length;
    }
}