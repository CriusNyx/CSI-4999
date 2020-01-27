using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util.Latches
{
    [Serializable]
    public class MasterLatch : ILatch
    {
        public enum LatchType
        {
            cooldown,
            dice,
            counter
        }

        public LatchType latchType = LatchType.cooldown;

        public Counter counter = new Counter();
        public Dice dice = new Dice();
        public Cooldown cooldown = new Cooldown();

        public ILatch CurrentLatch
        {
            get
            {
                switch(latchType)
                {
                    case LatchType.cooldown:
                    default:
                        return cooldown;
                    case LatchType.counter:
                        return counter;
                    case LatchType.dice:
                        return dice;
                }
            }
        }

        public bool Set()
        {
            return CurrentLatch.Set();
        }

        public bool Reset()
        {
            return CurrentLatch.Reset();
        }

        public bool IsSet()
        {
            return CurrentLatch.IsSet();
        }

        public void Trip()
        {
            CurrentLatch.Trip();
        }
    }
}
