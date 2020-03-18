using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actor.EnemyAI
{
    public abstract class AIBehaviour : MonoBehaviour
    {
        public abstract float RandomWeight { get; }
        public abstract float ExecutionTime { get; }
    }
}
