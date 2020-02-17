using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatsController;

public class StatsControllerTest : MonoBehaviour
{
    StatsController statsController;

    // Start is called before the first frame update
    void Start()
    {

        #region Testing / Debug
        statsController = gameObject.GetComponent<StatsController>();

        ModifierKey key = new ModifierKey();
        StatModifier modifier = new StatModifier("Debug Add After", key, 10, ModifierType.AddAfterMultiply);

        statsController.GetStat(StatType.Health).AddModifier(modifier);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
