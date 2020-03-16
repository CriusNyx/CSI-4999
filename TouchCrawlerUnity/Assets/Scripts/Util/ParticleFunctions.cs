using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParticleFunctions
{
    public static GameObject PlayOneOff(GameObject source, Vector3 position, Quaternion rotation)
    {
        GameObject output = GameObjectFactory.Instantiate(source, position, rotation);
        var particleSystem = output.GetComponentInChildren<ParticleSystem>();
        //particleSystem.Stop();
        particleSystem.Emit(1);

        float freezeTime = Time.time + 0.1f;

        FunctionalBehaviour.Create(
            particleSystem.gameObject,
            () =>
            {
                if (Time.time > freezeTime)
                {
                    bool delete = true;
                    foreach (var system in output.GetComponentsInChildren<ParticleSystem>())
                    {

                        if (system.particleCount > 0)
                            delete = false;
                    }
                    if (delete)
                    {
                        GameObject.Destroy(output);
                    }
                }
            });

        return output;
    }
}
