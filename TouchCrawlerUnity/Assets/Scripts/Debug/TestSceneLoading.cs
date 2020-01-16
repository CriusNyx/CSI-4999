using Assets.Scripts.Events;
using Assets.Scripts.SceneCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Debug
{
    public class TestSceneLoading : MonoBehaviour
    {
        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                EventSystem.Broadcast(EventSystem.EventChannel.gameState, EventSystem.EventSubChannel.levelTransition, new SceneTransitionEvent("Foo"));
            }
        }
    }
}
