using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public static class EditorGUICustomUtility
    {
        /// <summary>
        /// Draw a custom editor for an array that can add and remove elements dynamically
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="elementEditor"></param>
        /// <param name="addElementButtonName"></param>
        /// <returns></returns>
        public static T[] DrawArrayEditor<T>(T[] arr, Func<T, T> elementEditor, string addElementButtonName) => DrawArrayEditor<T>(arr, elementEditor, addElementButtonName, () => default(T));

        /// <summary>
        /// Draw a custom editor for an array that can add and remove elements dynamically
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="elementEditor"></param>
        /// <param name="addElementButtonName"></param>
        /// <param name="constructor"></param>
        /// <returns></returns>
        public static T[] DrawArrayEditor<T>(T[] arr, Func<T, T> elementEditor, string addElementButtonName, Func<T> constructor)
        {
            List<T> list = new List<T>(arr);
            int elementToRemove = -1;

            GuiLine(2, 5);

            for(int i = 0; i < list.Count; i++)
            {
                var element = list[i];
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label(element?.ToString());
                    if(GUILayout.Button("-", GUILayout.Width(20)))
                    {
                        elementToRemove = i;
                    }
                }
                GUILayout.EndHorizontal();

                element = elementEditor(element);
                list[i] = element;

                GuiLine(2, 5);
            }

            if(elementToRemove != -1)
            {
                list.RemoveAt(elementToRemove);
            }
            if(GUILayout.Button(addElementButtonName))
            {
                list.Add(constructor());
            }

            GuiLine(2, 5);
            GuiLine(2, 5);

            return list.ToArray();
        }

        /// <summary>
        /// Draw a horizontal line in the gui
        /// </summary>
        /// <param name="lineHeight"></param>
        /// <param name="padding"></param>
        public static void GuiLine(int lineHeight, int padding = 0) => GuiLine(lineHeight, padding, padding);

        /// <summary>
        /// Draw a horizontal line in the gui
        /// </summary>
        /// <param name="lineHeight"></param>
        /// <param name="paddingAbove"></param>
        /// <param name="paddingBelow"></param>
        public static void GuiLine(int lineHeight, int paddingAbove, int paddingBelow)
        {

            Rect rect = EditorGUILayout.GetControlRect(false, lineHeight);

            rect.height = lineHeight;

            GUILayout.Space(paddingAbove);

            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));

            GUILayout.Space(paddingBelow);
        }

        public static void DrawSelectableNameField(float padding, GameObject target, string undoName)
        {
            Undo.RecordObject(target, undoName);

            GUIStyle buttonStyle = GUI.skin.GetStyle("Button");
            GUIStyle testStyle = GUI.skin.GetStyle("textField");

            Color oldColor = GUI.color;

            if(Selection.activeGameObject == target)
            {
                GUI.color *= Color.red;
            }

            GUILayout.BeginHorizontal();
            {
                GUILayout.Space(padding);
                if(GUILayout.Button("+"))
                {
                    Selection.activeObject = target;
                }
                target.name = EditorGUILayout.TextField(target.name);
            }
            GUILayout.EndHorizontal();

            GUI.color = oldColor;
        }

        public static void DrawDefaultHandles(GameObject gameObject)
        {
            Undo.RecordObject(gameObject.transform, "Transform " + gameObject.name);

            switch(Tools.current)
            {
                case Tool.Move:
                    gameObject.transform.position = Handles.PositionHandle(Tools.handlePosition, Tools.handleRotation);
                    break;
            }
        }
    }
}
