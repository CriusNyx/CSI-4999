using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SceneCode
{
    public class SceneTransitionEvent : IEvent
    {
        public readonly string sceneName;

        public SceneTransitionEvent(string sceneName)
        {
            this.sceneName = sceneName;
        }

        public override string ToString()
        {
            return nameof(SceneTransitionEvent) + "(" + sceneName + ")";
        }
    }
}
