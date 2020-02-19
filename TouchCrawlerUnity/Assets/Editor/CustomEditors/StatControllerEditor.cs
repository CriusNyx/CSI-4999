using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using Assets.Scripts.Util;

[CustomEditor(typeof(StatsController))]
public class StatControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        //Custom editor just prints, no need to record undos
        StatsController statsController = target as StatsController;

        foreach(var statTypeObject in Enum.GetValues(typeof(StatsController.StatType)))
        {
            var statType = (StatsController.StatType)statTypeObject;
            var stat = statsController.GetStat(statType);

            if(stat == null)
            {
                GUILayout.Label(statType.ToString() + " is null");
            }
            else
            {
                //Print Stat value
                GUILayout.Label(statType.ToString() + " = " + stat.CalculateStatValue());
                

                //Get the stat modifiers
                IEnumerable<StatsController.StatModifier> modifiers = stat.ModifierMap.Values;

                if(modifiers.Count() == 0)
                {
                    GUILayout.Label("Modifiers: None");
                }

                foreach(var modifier in stat.ModifierMap.Values)
                {
                    GUILayout.Label("Modifiers: ");
                    GUILayout.Label(modifier.ToString().Indent("  "));
                }
            }
        }
    }
}
