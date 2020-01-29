using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultActor : MonoBehaviour, IActor
{
    public int actorLevel { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Rigidbody2D body => throw new System.NotImplementedException();

    public IActor target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public MovementController mc { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void AcceptEvent(Object E)
    {
        throw new System.NotImplementedException();
    }

    public bool CheckIfPlayer()
    {
        throw new System.NotImplementedException();
    }

    public void DecreaseStat()
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseStat()
    {
        throw new System.NotImplementedException();
    }

    public bool IsPlayer()
    {
        throw new System.NotImplementedException();
    }

    public void PickUpItem(Object item)
    {
        throw new System.NotImplementedException();
    }

    public void ProtectedStart()
    {
        throw new System.NotImplementedException();
    }

    public void StatModifier()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateActor()
    {
        throw new System.NotImplementedException();
    }

    public void UseItem(Object item)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
