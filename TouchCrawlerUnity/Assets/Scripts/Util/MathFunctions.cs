using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathFunctions
{
    public static float LogarithmicDecay(float decayPerUnit, float delta)
    {
        return 1f - Mathf.Pow(decayPerUnit, delta);
    }
}
