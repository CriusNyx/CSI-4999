using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cooldown
{
    public float cooldownTime = 0.1f;
    private float timeWhenReady = -1;

    public void ResetCooldown()
    {
        timeWhenReady = -1f;
    }

    public void TriggerCooldown()
    {
        timeWhenReady = Time.time + cooldownTime;
    }

    public bool IsReady()
    {
        return Time.time >= timeWhenReady;
    }
}
