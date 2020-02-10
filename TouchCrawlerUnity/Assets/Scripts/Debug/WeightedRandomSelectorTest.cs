using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedRandomSelectorTest : MonoBehaviour
{
    WeightedRandomSelector<int> weightedRandomSelector = new WeightedRandomSelector<int>();

    // Start is called before the first frame update
    void Start()
    {
        weightedRandomSelector.Add(0, 1f);
        weightedRandomSelector.Add(1, 0f);

        Dictionary<int, int> counter = new Dictionary<int, int>();
        counter[0] = 0;
        counter[1] = 0;
        for(int i = 0; i < 10000; i++)
        {
            counter[weightedRandomSelector.Select(Random.value)]++;
        }

        Debug.Log("0 count = " + counter[0] + ", 1 count = " + counter[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
