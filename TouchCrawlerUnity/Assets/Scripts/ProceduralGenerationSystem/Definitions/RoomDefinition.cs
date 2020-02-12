using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDefinition : MonoBehaviour
{
    public bool isSpawnRoom = false;
    public bool isBossRoom = false;
    public int minDifficulty = -1;
    public int maxDifficulty = -1;

    private void OnDrawGizmos()
    {
        Vector3 center = transform.position + Vector3.right * 2f + Vector3.up * 1f;
        Vector3 scale = new Vector3(16, 12, 0);
        Vector3 scalex = new Vector3(16, 0, 0);
        Vector3 scaley = new Vector3(0, 12, 0);

        //rooms are 16/12
        Gizmos.DrawWireCube(center, scale);

        Gizmos.DrawCube(center - scalex / 2f, Vector3.one);
        Gizmos.DrawCube(center + scalex / 2f, Vector3.one);
        Gizmos.DrawCube(center - scaley / 2f, Vector3.one);
        Gizmos.DrawCube(center + scaley / 2f, Vector3.one);
    }
}
