using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponComponent), true)]
public class ComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WeaponComponent component = target as WeaponComponent;

        Weapon weapon = component.GetComponent<Weapon>();
        if(weapon == null)
        {
            GUIStyle style = "label";
            style.richText = true;
            GUILayout.Label("<color=red>Warning:</color> <color=black>There is no weapon attached to this component.</color>");
        }
        Repaint();
    }
}