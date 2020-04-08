using Assets.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(LevelDefinition))]
public class LevelDefinitionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Label(target.name, "BoldLabel");

        LevelDefinition levelDefinition = target as LevelDefinition;

        EditorGUI.BeginChangeCheck();

        GUILayout.Label("Boss Room", "BoldLabel");
        GameObject bossRoom = levelDefinition.bossRoomToInstantiate;
        bossRoom = EditorGUILayout.ObjectField(bossRoom, typeof(GameObject), false) as GameObject;

        GUILayout.Label(new GUIContent("Inherrited Definitions", "These level definitions will be inherrited by the current level definition. It behaives a little like css."), "BoldLabel");

        var newDefinitionsToInherrit = levelDefinition.definitionsToInherrit =
            EditorGUICustomUtility.DrawArrayEditor(
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
        var newRoomArray = EditorGUICustomUtility.DrawArrayEditor(
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
                    CheckErrorRoomIsCenter(x);
                    CheckErrorObjectInPosition(x, "Walls", Vector3.zero);
                    CheckErrorObjectInPosition(x, "Ground", Vector3.zero);
                    CheckErrorObjectInPosition(x, "door_1000", new Vector3(0, 2, 0));
                    CheckErrorObjectInPosition(x, "door_0100", new Vector3(0, 3, 0));
                    CheckErrorObjectInPosition(x, "door_0010", new Vector3(0, 2, 0));
                    CheckErrorObjectInPosition(x, "door_0001", new Vector3(0, 0, 0));
                    CheckErrorObjectInPosition(x, "door_down", new Vector3(0, 0, 0));
                    CheckErrorObjectInPosition(x, "door_down/closed_down", new Vector3(0, 0, 0));
                    RoomHasGrid(x);
                }

                return x;
            },
            "Add Room");

        CheckErrorsForInherritdDefinitions(warningStyle, defs);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(levelDefinition, "Edited Level Definition: " + levelDefinition.name);
            levelDefinition.definitionsToInherrit = newDefinitionsToInherrit;
            levelDefinition.roomsToInstantiate = newRoomArray;
            levelDefinition.bossRoomToInstantiate = bossRoom;

            PrefabUtility.RecordPrefabInstancePropertyModifications(levelDefinition);

            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }

    private static void RoomHasGrid(GameObject x)
    {
        if(x.gameObject.GetComponent<Grid>() == null)
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.Label("<color=red>Warning:</color> Room is missing grid.\nThis will make it hard to edit.");
                if (GUILayout.Button("Fix", GUILayout.Width(70)))
                {
                    x.AddComponent<Grid>();
                }
            }
            GUILayout.EndHorizontal();
        }
    }

    private static void CheckErrorRoomIsCenter(GameObject x)
    {
        if (x.transform.position != Vector3.zero || x.transform.rotation != Quaternion.identity || x.transform.localScale != Vector3.one)
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

    public static void CheckErrorObjectInPosition(GameObject x, string objectName, Vector3 position)
    {
        GameObject child = x.transform.Find(objectName)?.gameObject;
        if (child != null)
        {
            if (child.transform.position != position || child.transform.rotation != Quaternion.identity || child.transform.localScale != Vector3.one)
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label($"<color=red>Warning:</color> Transform is not correct for {objectName}");
                    if(GUILayout.Button("Fix", GUILayout.Width(70)))
                    {
                        child.transform.position = position;
                        child.transform.rotation = Quaternion.identity;
                        child.transform.localScale = Vector3.one;
                    }
                }
                GUILayout.EndHorizontal();
            }
        }
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