using Assets.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(LevelDefinition))]
public class LevelDefinitionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Label(target.name);

        LevelDefinition levelDefinition = target as LevelDefinition;
        levelDefinition.definitionsToInherrit = ResizeableArrayEditor.DrawEditor(
            levelDefinition.definitionsToInherrit,
            (x) =>
            {
                return EditorGUILayout.ObjectField("", x, typeof(LevelDefinition), true) as LevelDefinition;
            },
            "Add Inherrited Definition");


        levelDefinition.roomsToInstantiate = ResizeableArrayEditor.DrawEditor(
            levelDefinition.roomsToInstantiate,
            (x) =>
            {
                return EditorGUILayout.ObjectField("", x, typeof(GameObject), true) as GameObject;
            },
            "Add Room");


        

        LevelDefinition[] defs = LevelDefinition.ResolveDependancies(levelDefinition);

        GUILayout.Space(50);

        GUILayout.Label("All Defs");
        foreach(var def in defs)
        {
            GUILayout.Label(def.name);
        }

        GUIStyle warningStyle = "label";
        warningStyle.richText = true;
        if (!defs.Any(x => x.name == "EveryLevel"))
        {
            GUILayout.Label("<color=red>Warning:</color> <color=black>This level does not inherrit EveryLevel.\nThis may result in the level not having critical components, like a spawn room.</color>", warningStyle);
        }
    }
}