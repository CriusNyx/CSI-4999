using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnSet))]
public class SpawnSetEditor : Editor
{
    private void OnSceneGUI()
    {
        SpawnSet spawnSet = target as SpawnSet;
        RoomDefinition roomDefinition = spawnSet.GetComponentInParent<RoomDefinition>();

        RoomDefinitionEditor.DrawRoomDefinitionEditorSceneGUI(roomDefinition);

        Repaint();
    }
}
