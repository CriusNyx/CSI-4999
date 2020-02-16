using Assets.Scripts.Events;

public class PickupItemTouchedEvent : IEvent
{
    public readonly PickUpItem item;

    public PickupItemTouchedEvent(PickUpItem item)
    {
        this.item = item;
    }
}