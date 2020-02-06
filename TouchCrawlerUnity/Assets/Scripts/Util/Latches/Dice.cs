
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Util.Latches
{
    [Serializable]
    public class Dice : ILatch
    {
        public float percentChance;

        public bool Roll() => IsSet();

        public bool IsSet()
        {
            return Random.value * 100f <= percentChance;
        }

        public bool Reset()
        {
            return false;
        }

        public bool Set()
        {
            return false;
        }

        public void Trip()
        {

        }
    }
}
