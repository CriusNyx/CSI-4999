using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
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

    void AcceptEvent(Object E);

    void UseItem(Object item);

    void PickUpItem(Object item);
}
