using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPauseController : MonoBehaviour
{
    //[Range(0f, 3f)]
    //public float duration = 0.05f;
    //// Magntiude of shake effect
    //[Range(0f, 1f)]
    //public float shakeMagnitude = 0.4f;

    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.R))
    //    {
    //        StartCoroutine(DoFreeze());
    //    }
    //}

    public void StartShake(float duration, float shakeMagnitude)
    {
        StartCoroutine(DoFreeze(duration, shakeMagnitude));
    }

    IEnumerator DoFreeze(float duration, float shakeMagnitude)
    {
        float pauseEndTime = Time.realtimeSinceStartup + duration;
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();

        // Store original position + rotation
        Vector3 originalPosition = transform.position;
        Quaternion originalRotation = transform.rotation;

        rigidBody.isKinematic = true;

        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            Shake(shakeMagnitude, duration, originalPosition, originalRotation);

            yield return null;
        }

        yield return null;

        rigidBody.isKinematic = false;
        // Go back to original position + rotation
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }

    private void Shake(float trauma, float length, Vector3 originalPosition, Quaternion originalRotation)
    {
        if (trauma > 0)
        {
            float offsetXYZ = Random.Range(-1f, 1f) * trauma;
            float cameraShake = Mathf.Pow(trauma, 2); // By default: 0.8

            // Note: The recurring number 25 is the "frequency" of the Perlin Noise
            float xPosition = originalPosition.x + (Mathf.PerlinNoise(offsetXYZ, Time.time * 25) * 2 - 1) * cameraShake;
            float yPosition = originalPosition.y + (Mathf.PerlinNoise(offsetXYZ + 1, Time.time * 25) * 2 - 1) * cameraShake;
            float zRotation = originalRotation.z + (Mathf.PerlinNoise(offsetXYZ + 5, Time.time * 25) * 2 - 1) * cameraShake;

            transform.position = new Vector3(xPosition, yPosition, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
        }
    }
}
