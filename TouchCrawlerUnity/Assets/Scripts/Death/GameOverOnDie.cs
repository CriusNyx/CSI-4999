using Assets.Scripts.Events;
using static Assets.Scripts.Events.EventSystem;

namespace Assets.Scripts.Death
{
    /// <summary>
    /// This event passes a game over event into the event system when the actor
    /// dies. Should only be used when a player dies.
    /// </summary>
    public class GameOverOnDie : OnDieEffect
    {
        public override void OnDie(IActor actor)
        {
            IEvent e = new GameOverEvent();
            Broadcast(EventChannel.gameState, EventSubChannel.gameOver, e);
        }
    }
}
