using System;
using System.Collections;
using UnityEngine;

public partial class ActorStatModifier : MonoBehaviour
{
    private StatsController statsController;
    public StatModifierSet modifierSet;

    private void OnEnable()
    {
        statsController = //GameObject.FindGameObjectWithTag("Player").GetComponent<StatsController>();
                          gameObject.GetComponentInParent<StatsController>();
        foreach (var (key, mod) in modifierSet.GetMods())
        {
            statsController.GetStat(mod.statToModify).AddModifier(new StatsController.StatModifier(mod.name, key, mod.value, mod.modifierType));
        }
    }

    private void OnDisable()
    {
        foreach(var (key, mod) in modifierSet.GetMods())
        {
            statsController.GetStat(mod.statToModify).RemoveModifier(key);
        }
    }

    [Serializable]
    public class StatModifierDefinition
    {
        public StatsController.StatType statToModify;
        public string name;
        public float value;
        public StatsController.ModifierType modifierType;
    }
}