using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using Assets.Scripts.Actor.EnemyAI;
using Assets.Scripts.Util;

public class EnemyAIController : MonoBehaviour
{
    //Behavior variables

    private float nextCheck = -1f;

    public void Update()
    {
        if (Time.time > nextCheck)
            SwapBehaviour();
    }

    private void SwapBehaviour()
    {
        WeightedRandomSelector<AIBehaviour> selector = new WeightedRandomSelector<AIBehaviour>();

        var behaviours = gameObject.GetComponents<AIBehaviour>();

        foreach (var behaviour in behaviours)
        {
            behaviour.enabled = false;
            selector.Add(behaviour, behaviour.RandomWeight);
        }
        var current = selector.Select(Random.value);
        if (current != null)
        {
            current.enabled = true;
            nextCheck = Time.time + current.ExecutionTime;
        }
    }
}