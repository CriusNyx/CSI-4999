using Assets.Scripts.Events;

public class DropItemEvent : IEvent
{
    public readonly Item item;

    public DropItemEvent(Item item)
    {
        this.item = item;
    }
}