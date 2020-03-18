using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Editor;

[CustomEditor(typeof(DropTable))]
public class DropTableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DropTable dropTable = target as DropTable;

        EditorGUI.BeginChangeCheck();

        var newItems = EditorGUICustomUtility.DrawArrayEditor<DropTableSlot>(
            dropTable.items, 
            (x) =>
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Weight", GUILayout.Width(50));
                    GUILayout.Label("Object");
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    x.weight = EditorGUILayout.FloatField(x.weight, GUILayout.Width(50));
                    x.drop = EditorGUILayout.ObjectField("", x.drop, typeof(GameObject), false) as GameObject;
                }
                GUILayout.EndHorizontal();
                return x;
            }, 
            "Add item");

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(dropTable, $"Edited Drop Table {dropTable.name}");
            dropTable.items = newItems;

            PrefabUtility.RecordPrefabInstancePropertyModifications(dropTable);

            EditorUtility.SetDirty(dropTable);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
