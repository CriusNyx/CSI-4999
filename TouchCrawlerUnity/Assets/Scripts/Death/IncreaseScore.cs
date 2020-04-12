using Assets.Scripts.Death;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Death
{
    public class IncreaseScore : OnDieEffect
    {
        public int value = 1;
        public override void OnDie(IActor actor)
        {
            if (!actor.IsPlayer())
            {
                UserSettings.score += value;
            }
        }

    }
}
