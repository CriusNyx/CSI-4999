using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatsController;

public interface IStats
{
    float BaseValue { get; set; }
    void AddModifier(StatModifier modifier);
    void RemoveModifier(ModifierKey key);
    bool ContainsKey(ModifierKey key);
    float CalculateStatValue();

    // Note: I need to make GetStat() and SetStat() easier to use via the interface

    //GetStat(Stat);
    //SetStat(Stat, float);
}
