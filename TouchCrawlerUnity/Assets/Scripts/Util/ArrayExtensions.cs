using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util
{
    public static class ArrayExtensions
    {
        public static bool BoundsCheck(this Array array, int index)
        {
            return index >= 0 && index < array.Length;
        }

        public static bool BoundsCheck<T>(this T[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }

        public static Array Fill<T>(Array array, Func<T> constructor)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array.SetValue(constructor(), i);
            }
            return array;
        }

        public static T[] Fill<T>(this T[] array, Func<T> constructor)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = constructor();
            }

            return array;
        }

        public static T[] Push<T>(this T[] arr)
        {
            T[] output = new T[arr.Length + 1];
            Array.Copy(arr, 0, output, 0, arr.Length);
            output[arr.Length] = default;
            return output;
        }

        public static T[] Remove<T>(this T[] arr, int indexToRemove)
        {
            T[] output = new T[arr.Length - 1];
            Array.Copy(arr, 0, output, 0, indexToRemove);
            Array.Copy(arr, indexToRemove + 1, output, indexToRemove, int.MaxValue);
            return output;
        }
    }
}
