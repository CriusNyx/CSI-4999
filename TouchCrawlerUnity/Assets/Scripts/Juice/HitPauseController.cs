using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPauseController : MonoBehaviour
{
    [Range(0f,3f)]
    public float duration = 1f;
    float pendingFreezeDuration = 0f;
    bool isFrozen = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(DoFreeze());
        }
    }

    IEnumerator DoFreeze()
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + duration;

        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }

        Time.timeScale = 1;
    }
}
