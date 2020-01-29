using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    int actorLevel {
        get;
        set;
    }
    Rigidbody2D body
    {
        get;
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
        set;
    }

    // Start is called before the first frame update
    void ProtectedStart();

    bool CheckIfPlayer();

    void AcceptEvent(Object E);

    // Update is called once per frame
    void UpdateActor();

    void UseItem(Object item);

    void PickUpItem(Object item);

    void IncreaseStat();

    void DecreaseStat();

    void StatModifier();
}
