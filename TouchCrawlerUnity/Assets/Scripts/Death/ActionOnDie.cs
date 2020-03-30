namespace Assets.Scripts.Death
{
    public class ActionOnDie : OnDieEffect
    {
        public System.Action<IActor> deathAction;

        public void createActionOnDie(System.Action<IActor> deathAction, IActor actor)
        {
            this.deathAction = deathAction;
            this.actor = actor;
        }

        public override void OnDie(IActor actor)
        { 
            deathAction?.Invoke(actor); 
        }
    }
}
