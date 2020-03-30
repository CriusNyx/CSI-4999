using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Death
{
    public class GameOverEventListener : MonoBehaviour, IEventListener {
        
        private GameObject gui;

        public void Start()
        {
            EventSystem.AddEventListener(EventSystem.EventChannel.gameState, EventSystem.EventSubChannel.gameOver, this);
        }

        public void OnDestroy()
        {
            EventSystem.RemoveEventListener(EventSystem.EventChannel.gameState, EventSystem.EventSubChannel.gameOver, this);
        }

        public void AcceptEvent(IEvent e)
        {
            if(e is GameOverEvent myEvent)
            {
                ShowScreen(myEvent);
            }
        }
        private void ShowScreen(GameOverEvent e)
        {
            gui = GameObject.Instantiate(Resources.Load("Prefabs/GUIs/GameOverScreen")) as GameObject;
        }
    }
}
