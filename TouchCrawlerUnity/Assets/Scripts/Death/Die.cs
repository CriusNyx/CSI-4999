using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Events.EventSystem;

namespace Assets.Scripts.Death
{
    /// <summary>
    /// OnDieEffect is the base class for any action that is suppose to happen
    /// upon the death of an actor. To add a new OnDieEffect, simply inheirit OnDieEffect
    /// and implement OnDie.
    /// </summary>
    abstract class OnDieEffect : MonoBehaviour
    {
        public IActor actor { get; set; }
        public abstract void OnDie(IActor actor);

    }

    /// <summary>
    /// This OnDieEffect broadcasts a passed event into the event system when
    /// an actor dies. Channel information is defined in Events.EventSystem
    /// </summary>
    class PassEventsOnDie : OnDieEffect
    {
        public IEvent eventOnDie = new DeathEvent(null);
        public EventChannel channel = EventChannel.gameState;
        public EventSubChannel subChannel = EventSubChannel.gameOver;
        public PassEventsOnDie()
        {
            Broadcast(channel, subChannel, eventOnDie);
        }

        public override void OnDie(IActor actor) { this.actor = actor; }
    }

    class ActionOnDie : OnDieEffect
    {
        public System.Action<IActor> deathAction;
        IActor actor;
        public void createActionOnDie(System.Action<IActor> deathAction, IActor actor)
        {
            this.deathAction = deathAction;
            this.actor = actor;
        }

        public override void OnDie(IActor actor) { deathAction.Invoke(actor); }
    }


    /// <summary>
    /// This event destroys the actors gameobject when it dies.
    /// </summary>
    class DestructionOnDie : OnDieEffect
    {
        public DestructionOnDie() 
        {
            Destroy(actor.gameObject);
        }

        public override void OnDie(IActor actor) { this.actor = actor; }
    }

    /// <summary>
    /// This event passes a game over event into the event system when the actor
    /// dies. Should only be used when a player dies.
    /// </summary>
    class GameOver : OnDieEffect
    {
        public override void OnDie(IActor actor) { this.actor = actor; }
        public GameOver()
        {
            if (actor.IsPlayer()) {
                IEvent e = new GameOverEvent();
                Broadcast(EventChannel.gameState, EventSubChannel.gameOver, e);
            }
        }
    }

    /// <summary>
    /// This effects passes a drop event to the event system when an actor dies.
    /// </summary>
    class DropItem : OnDieEffect
    {
        public override void OnDie(IActor actor) { this.actor = actor; }

        public DropItem()
        {
            IEvent e = new DropEvent(actor);
            Broadcast(EventChannel.gameState, EventSubChannel.item, e);
        }
    }


}
