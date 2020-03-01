using Assets.Scripts.Events;

public class PickupItemTouchedEvent : IEvent
{
    public readonly Item item;

    public PickupItemTouchedEvent(Item item)
    {
        this.item = item;
    }
}