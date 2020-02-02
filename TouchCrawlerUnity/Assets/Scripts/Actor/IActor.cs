using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor : Assets.Scripts.Events.IEventListener
{
    int actorLevel {
        get;
        set;
    }

    IActor target
    {
        get;
        set;
    }
    MovementController movementController
    {
        get;
    }

    /*StatController statController{
     * get;
     * }
     */

    bool IsPlayer();

    void UseItem(object item);

    void PickUpItem(object item);
}
