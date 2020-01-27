using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util.Latches
{
    [Serializable]
    public class Counter : ILatch
    {
        public int targetCount = 1;

        public int CurrentCount { get; set; }

        public bool IsSet()
        {
            CurrentCount++;
            if(CurrentCount > targetCount)
            {
                CurrentCount = targetCount;
            }
            return CurrentCount >= targetCount;
        }

        public bool Reset()
        {
            CurrentCount = 0;
            return true;
        }

        public bool Set()
        {
            CurrentCount = targetCount;
            return true;
        }

        public void Trip()
        {
            Reset();
        }
    }
}
