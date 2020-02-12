using System.Collections.Generic;
using UnityEngine;
using static ActorStatModifier;

[CreateAssetMenu(fileName = "ModifierSet", menuName = "Scriptable Objects/Modifier Set", order = 100000000)]
public class StatModifierSet : ScriptableObject
{

    private Dictionary<StatModifierDefinition, StatsController.ModifierKey> keyMap = new Dictionary<StatModifierDefinition, StatsController.ModifierKey>();
    [SerializeField]
    private StatModifierDefinition[] modifiers;

    public IEnumerable<(StatsController.ModifierKey, StatModifierDefinition)> GetMods()
    {
        foreach(var mod in modifiers)
        {
            yield return (GetKey(mod), mod);
        }
    }

    private StatsController.ModifierKey GetKey(StatModifierDefinition modDefinition)
    {
        if(!keyMap.ContainsKey(modDefinition))
        {
            keyMap[modDefinition] = new StatsController.ModifierKey();
        }
        return keyMap[modDefinition];
    }
}