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
        

        GUILayout.Label(target.name, "BoldLabel");

        LevelDefinition levelDefinition = target as LevelDefinition;

        Undo.RecordObject(levelDefinition, "Edited Level Definition \"" + levelDefinition.name + "\"");


        GUILayout.Label(new GUIContent("Inherrited Definitions", "These level definitions will be inherrited by the current level definition."), "BoldLabel");

        levelDefinition.definitionsToInherrit =
            Assets.Editor.EditorGUIUtility.DrawArrayEditor(
                levelDefinition.definitionsToInherrit,
                (x) =>
                {
                    return EditorGUILayout.ObjectField("", x, typeof(LevelDefinition), true) as LevelDefinition;
                },
                "Add Inherrited Definition");




        GUIStyle warningStyle = "label";
        warningStyle.richText = true;


        LevelDefinition[] defs = LevelDefinition.ResolveDependancies(levelDefinition);

        GUILayout.Space(10);

        GUILayout.Label("All Inherrited Definitions", "BoldLabel");

        foreach (var def in defs)
        {
            GUILayout.Label(def.name);
        }

        GUILayout.Space(50);



        GUILayout.Label(new GUIContent("Room Prefabs", "A set of rooms that can spawn on this level."), "BoldLabel");
        levelDefinition.roomsToInstantiate = Assets.Editor.EditorGUIUtility.DrawArrayEditor(
            levelDefinition.roomsToInstantiate,
            (x) =>
            {
                x = EditorGUILayout.ObjectField("", x, typeof(GameObject), true) as GameObject;

                if (x != null)
                {
                    var roomData = x.GetComponent<RoomDefinition>();
                    if (roomData == null)
                    {
                        GUILayout.BeginHorizontal();
                        {
                            GUILayout.Label("<color=red>Warning:</color> Room is missing definition");
                            if (GUILayout.Button("Fix", GUILayout.Width(70)))
                            {
                                x.AddComponent<RoomDefinition>();
                            }
                        }
                        GUILayout.EndHorizontal();
                    }
                    else
                    {
                        Editor editor = Editor.CreateEditor(roomData);
                        editor.OnInspectorGUI();
                    }
                    if (x.transform.position != Vector3.zero | x.transform.rotation != Quaternion.identity | x.transform.localScale != Vector3.one)
                    {
                        GUILayout.BeginHorizontal();
                        {
                            GUILayout.Label("<color=red>Warning:</color> Transform is not center");
                            if (GUILayout.Button("Fix", GUILayout.Width(70)))
                            {
                                x.transform.position = Vector3.zero;
                                x.transform.rotation = Quaternion.identity;
                                x.transform.localScale = Vector3.one;
                            }
                        }
                        GUILayout.EndHorizontal();
                    }
                }

                return x;
            },
            "Add Room");



        CheckErrorsForInherritdDefinitions(warningStyle, defs);
    }

    private static void CheckErrorsForInherritdDefinitions(GUIStyle warningStyle, LevelDefinition[] defs)
    {
        CheckErrorForFailureToInherritEveryLevel(defs, warningStyle);
    }

    private static void CheckErrorForFailureToInherritEveryLevel(LevelDefinition[] defs, GUIStyle warningStyle)
    {
        if (!defs.Any(x => x.name == "EveryLevel"))
        {
            GUILayout.Label("<color=red>Warning:</color> <color=black>This level does not inherrit EveryLevel.\nThis may result in the level not having critical components, like a spawn room.</color>", warningStyle);
        }
    }
}