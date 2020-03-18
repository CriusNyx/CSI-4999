using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Death
{
    class GameOverEvent : IEvent
    {
    }

    public class GameOverEventListener : IEventListener {
        
        public GameObject gui;

        public void AcceptEvent(IEvent e){
            if(e is GameOverEvent myEvent){
                ShowScreen(myEvent);
            }
        }
        private void ShowScreen(GameOverEvent e){   
            gui = GameObject.Instantiate(Resources.Load("GameOverScreen")) as GameObject;
        }
    }

    
}
