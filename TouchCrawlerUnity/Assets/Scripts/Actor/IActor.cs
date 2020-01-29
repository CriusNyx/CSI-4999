using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor : Assets.Scripts.Events.IEvent
{
    int actorLevel {
        get;
        set;
    }

    enum actorClass
    {

    }
    IActor target
    {
        get;
        set;
    }
    MovementController mc
    {
        get;
    }
    /*StatController sc{
     * get;
     * }
     */

    bool IsPlayer();

    void UseItem(object item);

    void PickUpItem(object item);
}
