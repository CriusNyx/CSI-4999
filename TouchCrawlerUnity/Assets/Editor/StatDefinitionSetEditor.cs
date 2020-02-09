using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using static ActorStatModifier;
using Assets.Scripts.Util;
using Assets.Editor;

[CustomEditor(typeof(StatModifierSet))]
public class StatDefinitionSetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        StatModifierSet statModifier = target as StatModifierSet;

        GUILayout.Label("Stat Modifier Set");

        StatModifierDefinition[] arr = typeof(StatModifierSet).GetField("modifiers", (BindingFlags)(-1)).GetValue(statModifier) as StatModifierDefinition[];

        //List<StatModifierDefinition> list = new List<StatModifierDefinition>(arr);

        //StatModifierDefinition remove = null;

        //foreach(var def in list)
        //{
        //    GUILayout.Label("Mod");
        //    GUILayout.BeginHorizontal();
        //    {
        //        def.name = EditorGUILayout.TextField("\tName", def.name);
        //        if(GUILayout.Button("-", GUILayout.Width(25)))
        //        {
        //            remove = def;
        //        }
        //    }
        //    GUILayout.EndHorizontal();


        //    def.statToModify = (StatsController.StatType)EditorGUILayout.EnumPopup("\tStat To Modify", def.statToModify);

        //    def.modifierType = (StatsController.ModifierType)EditorGUILayout.EnumPopup("\tModifier Type", def.modifierType);

        //    def.value = EditorGUILayout.FloatField("\tModifier Value", def.value);
        //}

        //GUILayout.Space(50);

        //if(remove != null)
        //{
        //    list.Remove(remove);
        //}

        //if(GUILayout.Button("Add Mod"))
        //{
        //    list.Add(new StatModifierDefinition());
        //}

        arr = ResizeableArrayEditor.DrawEditor(
            arr,
            (def) =>
            {
                def.statToModify = (StatsController.StatType)EditorGUILayout.EnumPopup("\tStat To Modify", def.statToModify);

                def.modifierType = (StatsController.ModifierType)EditorGUILayout.EnumPopup("\tModifier Type", def.modifierType);

                def.value = EditorGUILayout.FloatField("\tModifier Value", def.value);

                return def;
            },
            "Add Mod",
            () => new StatModifierDefinition());

        typeof(StatModifierSet).GetField("modifiers", (BindingFlags)(-1)).SetValue(statModifier, arr);
    }
}