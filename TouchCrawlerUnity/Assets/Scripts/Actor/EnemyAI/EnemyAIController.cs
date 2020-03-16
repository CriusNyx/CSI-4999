using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;

[RequireComponent(typeof(AIBehaviorAttack))]
[RequireComponent(typeof(AIBehaviorWander))]
[RequireComponent(typeof(AIBehaviorPatrol))]
public class EnemyAIController : MonoBehaviour
{
    //Behavior variables

    public int stopDuration;
    private int stopTime;
    public bool wander = false, patrol = false, attack = false;


    //Actor components
    private AIBehaviorPatrol aIBehaviorPatrol;
    private AIBehaviorWander aIBehaviorWander;
    private AIBehaviorAttack aIBehaviorAttack;
    private Rigidbody2D body;
    private MovementController movementController;
    private DefaultActor actor;
    

    void Start()
    {
        movementController = GetComponent<MovementController>();
        stopTime = 0;
        aIBehaviorAttack = GetComponent<AIBehaviorAttack>();
        aIBehaviorPatrol = GetComponent<AIBehaviorPatrol>();
        aIBehaviorWander = GetComponent<AIBehaviorWander>();
        aIBehaviorWander.enabled = false;
        aIBehaviorPatrol.enabled = false;
        aIBehaviorAttack.enabled = false;
        actor = GetComponent<NPCActor>();
        body = GetComponent<Rigidbody2D>();
        aIBehaviorAttack.enabled = attack;
        aIBehaviorPatrol.enabled = patrol;
        aIBehaviorWander.enabled = wander;
        Debug.Log(aIBehaviorWander.isActiveAndEnabled);
        if (wander)
        {
            aIBehaviorWander.enabled = true;
            aIBehaviorPatrol.enabled = false;
            aIBehaviorAttack.enabled = false;
        }else if (patrol)
        {
            aIBehaviorWander.enabled = false;
            aIBehaviorPatrol.enabled = true;
            aIBehaviorAttack.enabled = false;
        }
        else if (attack)
        {
            aIBehaviorWander.enabled = false;
            aIBehaviorPatrol.enabled = false;
            aIBehaviorAttack.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wander)
        {
            aIBehaviorWander.enabled = true;
            aIBehaviorPatrol.enabled = false;
            aIBehaviorAttack.enabled = false;
        }
        else if (patrol)
        {
            aIBehaviorWander.enabled = false;
            aIBehaviorPatrol.enabled = true;
            aIBehaviorAttack.enabled = false;
        }
        else if (attack)
        {
            aIBehaviorWander.enabled = false;
            aIBehaviorPatrol.enabled = false;
            aIBehaviorAttack.enabled = true;
        }
        if (WasAttackedYet())
        {
            StartAttacking();
        }
    }
    





    private bool WasAttackedYet()
    {
        return actor.wasAttacked;
    }

    private void StartAttacking()
    {
        aIBehaviorAttack.enabled = true;
        aIBehaviorPatrol.enabled = false;
        aIBehaviorWander.enabled = false;
    }
}
