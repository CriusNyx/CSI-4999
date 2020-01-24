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
        public static GameObject Create(string name = "GameObject", Vector3 position = default, Quaternion rotation = default)
        {
            return Create(
                () => new GameObject(name),
                position,
                rotation);
        }

        public static GameObject Instantiate(GameObject original, Vector3 position = default, Quaternion rotation = default)
        {
            return Create(
                () => Instantiate(original), 
                position, 
                rotation);
        }

        public static GameObject Create(Func<GameObject> constructor, Vector3 position = default, Quaternion rotation = default)
        {
            GameObject output = constructor();

            output.transform.position = position;
            output.transform.rotation = rotation;

            return output;
        }
    }
}
