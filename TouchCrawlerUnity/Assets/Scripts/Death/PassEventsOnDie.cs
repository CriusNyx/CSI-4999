using Assets.Scripts.Events;
using static Assets.Scripts.Events.EventSystem;

namespace Assets.Scripts.Death
{
    /// <summary>
    /// This OnDieEffect broadcasts a passed event into the event system when
    /// an actor dies. Channel information is defined in Events.EventSystem
    /// </summary>
    public class PassEventsOnDie : OnDieEffect
    {
        public IEvent eventOnDie = new DeathEvent(null);
        public EventChannel channel = EventChannel.gameState;
        public EventSubChannel subChannel = EventSubChannel.gameOver;

        public override void OnDie(IActor actor) 
        { 
            Broadcast(channel, subChannel, eventOnDie); 
        }
    }


}
