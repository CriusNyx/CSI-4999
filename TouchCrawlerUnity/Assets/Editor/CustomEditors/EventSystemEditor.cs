using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventSystem))]
public class EventSystemEditor : Editor
{
    private bool displayLog = true;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var log = EventSystem.Log;

        displayLog = GUILayout.Toggle(displayLog, "Display Log", "Button");
        if(displayLog)
        {
            foreach(var message in log)
            {
                GUILayout.Label(message);
            }
        }

        Repaint();
    }
}
