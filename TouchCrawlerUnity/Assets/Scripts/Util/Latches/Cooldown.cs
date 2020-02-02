using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cooldown : ILatch
{
    public float cooldownTime = 0.1f;
    private float timeWhenReady = -1;

    public bool Set()
    {
        timeWhenReady = -1f;
        return true;
    }

    public bool Reset()
    {
        timeWhenReady = Time.time + cooldownTime;
        return true;
    }

    public bool IsSet()
    {
        return Time.time >= timeWhenReady;
    }

    public void Trip() => Reset();
}
