using Assets.Scripts.Events;
using static Assets.Scripts.Events.EventSystem;

namespace Assets.Scripts.Death
{
    /// <summary>
    /// This effects passes a drop event to the event system when an actor dies.
    /// </summary>
    public class DropItemOnDie : OnDieEffect
    {
        public override void OnDie(IActor actor) 
        {
            IEvent e = new DropEvent(actor);
            Broadcast(EventChannel.gameState, EventSubChannel.item, e);
        }
    }


}
