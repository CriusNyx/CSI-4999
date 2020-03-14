using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropTable", menuName = "DropTable")]
public class DropTable : ScriptableObject
{
    public DropTableSlot[] items;

    WeightedRandomSelector<GameObject> weightedRandomSelector = new WeightedRandomSelector<GameObject>();

    public GameObject GetRandom()
    {
        for(int i = 0; i < items.Length; i++)
        {
            weightedRandomSelector.Add(items[i].drop, items[i].weight);
        }
        return weightedRandomSelector.Select(Random.value);
    }
}
