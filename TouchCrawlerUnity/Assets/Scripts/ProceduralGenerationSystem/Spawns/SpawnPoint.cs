using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
