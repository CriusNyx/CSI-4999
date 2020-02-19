using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnPoint))]
public class SpawnPointEditor : Editor
{
    private void OnSceneGUI()
    {
        SpawnPoint spawnSet = target as SpawnPoint;
        RoomDefinition roomDefinition = spawnSet.GetComponentInParent<RoomDefinition>();

        RoomDefinitionEditor.DrawRoomDefinitionEditorSceneGUI(roomDefinition);

        Repaint();
    }
}
