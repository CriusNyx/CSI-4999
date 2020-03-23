using Assets.Scripts.Death;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private HashSet<GameObject> enemiesToTrack = new HashSet<GameObject>();
    public event Action OnEmpty;

    public void Track(GameObject gameObject)
    {
        if(gameObject != null)
        {
            enemiesToTrack.Add(gameObject);
            TrackedGameObject.Create(gameObject, this);
        }
    }

    public void Remove(GameObject gameObject)
    {
        enemiesToTrack.Remove(gameObject);
        Trip();
    }

    public void Trip()
    {
        if(enemiesToTrack.Count == 0)
        {
            OnEmpty?.Invoke();
        }
    }
}

public class TrackedGameObject : MonoBehaviour
{
    private EnemyTracker tracker;

    public static TrackedGameObject Create(GameObject gameObject, EnemyTracker tracker)
    {
        var tracked = gameObject.AddComponent<TrackedGameObject>();
        tracked.tracker = tracker;
        return tracked;
    }

    private void OnDestroy()
    {
        tracker.Remove(gameObject);
    }
}
