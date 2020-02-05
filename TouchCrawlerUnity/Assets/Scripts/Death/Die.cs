﻿using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Events.EventSystem;

namespace Assets.Scripts.Death
{
    abstract class OnDieEffect : MonoBehaviour
    {
        public IActor actor { get; set; }
        public abstract void OnDie(IActor actor);

    }

    class PassEventsOnDie : OnDieEffect
    {
        public IEvent eventOnDie;
        public EventChannel channel;
        public EventSubChannel subChannel;
        public PassEventsOnDie()
        {
            Broadcast(channel, subChannel, eventOnDie);
        }

        public override void OnDie(IActor actor) { this.actor = actor; }
    }

    class DestructionOnDie : OnDieEffect
    {
        public DestructionOnDie() 
        {
            Destroy(actor.gameObject);
        }

        public override void OnDie(IActor actor) { this.actor = actor; }
    }

    class GameOver : OnDieEffect
    {
        public override void OnDie(IActor actor) { this.actor = actor; }
        public GameOver()
        {
            IEvent e = new GameOverEvent();
            Broadcast(EventChannel.gameState, EventSubChannel.gameOver, e);
        }
    }


}
