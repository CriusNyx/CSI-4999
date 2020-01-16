using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.SceneCode
{
    public class SceneLoader : MonoBehaviour, IEventListener
    {
        public void AcceptEvent(IEvent e)
        {
            if(e is SceneTransitionEvent sceneTransition)
            {
                SceneManager.LoadScene(sceneTransition.sceneName, LoadSceneMode.Single);
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(gameObject);
            EventSystem.AddEventListener(EventSystem.EventChannel.gameState, EventSystem.EventSubChannel.levelTransition, this);
        }
    }
}
