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

        Undo.RecordObject(statModifier, "Edit Stat Modifier Set \"" + target.name + "\"");

        GUILayout.Label(target.name, "BoldLabel");


        //Use reflection to get private array
        FieldInfo modifiersField = typeof(StatModifierSet).GetField("modifiers", (BindingFlags)(-1));
        StatModifierDefinition[] arr = modifiersField.GetValue(statModifier) as StatModifierDefinition[];

        //Draw editor for array
        arr = Assets.Editor.EditorGUIUtility.DrawArrayEditor(
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

        //use reflection to set private property
        modifiersField.SetValue(statModifier, arr);
    }
}