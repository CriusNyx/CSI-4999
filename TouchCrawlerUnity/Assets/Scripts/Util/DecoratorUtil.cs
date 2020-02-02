using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util
{
    public static class DecoratorUtil
    {
        public static T PropegateMonad<U, T>(
            T monad, 
            IEnumerable<U> list, 
            Func<U, T, T> func)
        {
            foreach(var u in list)
            {
                monad = func(u, monad);
            }
            return monad;
        }
    }
}
