using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Scripts.Util;
using Assets.Editor;
using System;

[CustomEditor(typeof(RoomDefinition))]
public class RoomDefinitionEditor : Editor
{
    private static Vector2 scrollPosition;

    private void OnSceneGUI()
    {
        RoomDefinition roomDefinition = target as RoomDefinition;

        DrawRoomDefinitionEditorSceneGUI(target as RoomDefinition);

        Repaint();
    }

    public static void DrawRoomDefinitionEditorSceneGUI(RoomDefinition roomDefinition)
    {
        Handles.BeginGUI();
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(250), GUILayout.Height(500));
            {
                foreach (var spawnSet in roomDefinition.GetComponentsInChildren<SpawnSet>())
                {
                    EditorGUICustomUtility.DrawSelectableNameField(0, spawnSet.gameObject, "Edit Spawn Set");
                    spawnSet.weight = EditorGUILayout.FloatField("Weight", spawnSet.weight);

                    foreach (var spawnPoint in spawnSet.GetComponentsInChildren<SpawnPoint>())
                    {
                        EditorGUICustomUtility.DrawSelectableNameField(20, spawnPoint.gameObject, "Edit Spawn Point");
                    }

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(20);
                        if (GUILayout.Button("Add Spawn Point"))
                        {
                            var spawnPoint = GameObjectFactory.Create("SpawnPoint", Vector3.zero, Quaternion.identity, spawnSet.transform);
                            spawnPoint.AddComponent<SpawnPoint>();
                            Undo.RegisterCreatedObjectUndo(spawnPoint, "Create Spawn Point");
                        }
                    }
                    GUILayout.EndHorizontal();
                }
                if (GUILayout.Button("Create new Spawn Set"))
                {
                    var spawnSet = GameObjectFactory.Create("SpawnSet", Vector3.zero, Quaternion.identity, roomDefinition.transform);
                    spawnSet.AddComponent<SpawnSet>();
                    Undo.RegisterCreatedObjectUndo(spawnSet, "Create Spawn Set");
                }
            }
            EditorGUILayout.EndScrollView();
        }
        Handles.EndGUI();
    }
}