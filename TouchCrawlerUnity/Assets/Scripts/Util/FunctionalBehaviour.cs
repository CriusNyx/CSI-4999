using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionalBehaviour : MonoBehaviour
{
    Action update;

    public static FunctionalBehaviour Create(GameObject owner, Action update)
    {
        return owner.AddComponent<FunctionalBehaviour>().Init(update);
    }

    private FunctionalBehaviour Init(Action update)
    {
        this.update = update;
        return this;
    }

    private void Update()
    {
        update?.Invoke();
    }
}