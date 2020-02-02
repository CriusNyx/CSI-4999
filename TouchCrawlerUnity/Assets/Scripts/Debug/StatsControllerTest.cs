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
        /*statsController = gameObject.GetComponent<StatsController>();

        ModifierKey key = new ModifierKey();
        StatModifier modifier = new StatModifier(key, 10, ModifierType.Flat);

        statsController.GetStat(StatType.Health).AddModifier(modifier);
        Debug.Log("should be true: " + statsController.GetStat(StatType.Health).ContainsKey(key));
        Debug.Log("stat value should equal 20: " + statsController.GetStat(StatType.Health).CalculateStatValue());

        statsController.GetStat(StatType.Health).RemoveModifier(key);

        Debug.Log("should be false: " + statsController.GetStat(StatType.Health).ContainsKey(key));
        Debug.Log("stat value should equal 10: " + statsController.GetStat(StatType.Health).CalculateStatValue());*/
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
