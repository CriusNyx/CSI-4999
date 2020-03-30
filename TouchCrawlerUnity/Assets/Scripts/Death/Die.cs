using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Death
{
    /// <summary>
    /// OnDieEffect is the base class for any action that is suppose to happen
    /// upon the death of an actor. To add a new OnDieEffect, simply inheirit OnDieEffect
    /// and implement OnDie.
    /// </summary>
    public abstract class OnDieEffect : MonoBehaviour
    {
        public IActor actor { get; set; }
        public abstract void OnDie(IActor actor);

    }
}
