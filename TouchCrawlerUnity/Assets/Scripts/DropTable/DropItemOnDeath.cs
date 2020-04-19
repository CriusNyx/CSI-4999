using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemOnDeath : MonoBehaviour
{
    private static DropTable dropTable;
    private static DropTable DropTable
    {
        get
        {
            if (dropTable == null)
            {
                dropTable = Resources.Load<DropTable>("ProceduralGenerationSystem/DropTable");
            }
            return dropTable;
        }
    }

    public float dropPercent = 0.1f;

    private void OnDestroy()
    {
        //if (Random.value <= dropPercent)
        {
            var dropTable = DropTable;
            var drop = dropTable.GetRandom();
            DropItemDispatcher.Create(drop, transform.position);
        }
    }
}
