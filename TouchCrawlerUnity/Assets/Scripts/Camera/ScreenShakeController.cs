using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    public Camera mainCamera;

    // Trauma length and amount
    public float shakeAmount;
    public float shakeTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shake(shakeAmount, shakeTime));
            //Shake(shakeAmount, shakeTime); // This will not work
        }
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
        this.shakeAmount = trauma;
        this.shakeTime = length;

        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;

        if (trauma > 0)
        {
            while (elapsed < length)
            {
                // Camera Shake = trauma^2
                // Shake Angle = maxAngle * trauma * RandomFloatFromNegOneToOne
                // OffsetX = maxOffset * trauma * RandomFloatFromNegOneToOne
                // Offset Y = maxOffset * trauma * RandomFloatFromNegOneToOne

                float offsetX = Random.Range(-1f, 1f) * shakeAmount;
                float offsetY = Random.Range(-1f, 1f) * shakeAmount;

                transform.localPosition = new Vector3(offsetX, offsetY, originalPosition.z);
                elapsed += Time.deltaTime;
                
                yield return null;
            }

            transform.localPosition = originalPosition;
        }
    }
}
