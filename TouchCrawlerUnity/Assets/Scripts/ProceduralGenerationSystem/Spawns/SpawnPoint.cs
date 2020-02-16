using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Util;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefab;

    private void OnDrawGizmos()
    {
        bool selected = false;
#if UNITY_EDITOR
        selected = Selection.Contains(gameObject);
#endif
        if (selected)
        {
            Gizmos.DrawIcon(transform.position, "Icons/enemy_spawn_selected.png", false);
        }
        else
        {
            Gizmos.DrawIcon(transform.position, "Icons/enemy_spawn.png", false);
        }
    }

    public GameObject Spawn()
    {
        return GameObjectFactory.Instantiate(prefab, transform.position, transform.rotation);
    }
}
