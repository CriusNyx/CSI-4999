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
    }
}
