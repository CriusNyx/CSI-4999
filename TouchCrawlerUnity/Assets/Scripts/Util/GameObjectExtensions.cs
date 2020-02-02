using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public static class GameObjectExtensions
    {
        public static T EnsureComponent<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            T output = gameObject.GetComponent<T>();
            if(output == null)
            {
                output = gameObject.AddComponent<T>();
            }
            return output;
        }
    }
}
