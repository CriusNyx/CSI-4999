namespace Assets.Scripts.Death
{
    /// <summary>
    /// This event destroys the actors gameobject when it dies.
    /// </summary>
    public class DestructionOnDie : OnDieEffect
    {
        public override void OnDie(IActor actor)
        {
            Destroy(actor.gameObject);
        }
    }


}
