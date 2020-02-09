using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Editor
{
    public static class ResizeableArrayEditor
    {
        public static T[] DrawEditor<T>(T[] arr, Func<T, T> elementEditor, string addElementButtonName) => DrawEditor<T>(arr, elementEditor, addElementButtonName, () => default(T));

        public static T[] DrawEditor<T>(T[] arr, Func<T, T> elementEditor, string addElementButtonName, Func<T> constructor)
        {
            List<T> list = new List<T>(arr);
            int elementToRemove = -1;

            for (int i = 0; i < list.Count; i++)
            {
                var element = list[i];
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label(element?.ToString());
                    if (GUILayout.Button("-", GUILayout.Width(20)))
                    {
                        elementToRemove = i;
                    }
                }
                GUILayout.EndHorizontal();

                element = elementEditor(element);
                list[i] = element;
            }

            GUILayout.Space(50);

            if (elementToRemove != -1)
            {
                list.RemoveAt(elementToRemove);
            }
            if (GUILayout.Button(addElementButtonName))
            {
                list.Add(constructor());
            }

            return list.ToArray();
        }
    }
}
