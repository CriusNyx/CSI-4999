using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public static class GameObjectFactory
    {
        public static GameObject Create(string name = "GameObject", Vector3 position = default, Quaternion rotation = default, Transform parent = default)
        {
            return Create(
                () => new GameObject(name),
                position,
                rotation,
                parent);
        }

        public static GameObject Instantiate(GameObject original, Vector3 position = default, Quaternion rotation = default, Transform parent = default)
        {
            return Create(
                () => GameObject.Instantiate(original), 
                position, 
                rotation,
                parent);
        }

        public static GameObject Create(Func<GameObject> constructor, Vector3 position = default, Quaternion rotation = default, Transform parent = default)
        {
            GameObject output = constructor();

            output.transform.position = position;
            output.transform.rotation = rotation;

            output.transform.parent = parent;

            return output;
        }
    }
}
