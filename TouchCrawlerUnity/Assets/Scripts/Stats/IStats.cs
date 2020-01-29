using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStats
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Void methods defined in StatsController
    void AddModifier(StatObject stat, ModifierTypeEnum modType, StatModifierObject modifier);

    void RemoveModifier(StatObject stat, ModifierTypeEnum modType, StatModifierObject modifier);

    void CalculateNewStats(StatObject stat, ModifierTypeEnum modType, StatModifierObject modifier);
}
