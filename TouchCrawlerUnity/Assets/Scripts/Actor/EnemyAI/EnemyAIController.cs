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
    private bool wasLastBehaviorWander;


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
        wasLastBehaviorWander = false;
        if (aIBehaviorWander.enabled)
        {
            wasLastBehaviorWander = true;
            aIBehaviorWander.enabled = true;
            aIBehaviorPatrol.enabled = false;
            aIBehaviorAttack.enabled = false;
        }
        if(aIBehaviorPatrol.enabled)
        {
            aIBehaviorWander.enabled = false;
            aIBehaviorPatrol.enabled = true;
            aIBehaviorAttack.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (WasAttackedYet() && aIBehaviorAttack.hasTarget)
        {
            StartAttacking();
        }
        if (!aIBehaviorAttack.hasTarget)
        {
            StopAtttacking();
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
    
    private void StopAtttacking()
    {
        aIBehaviorAttack.enabled = false;
        if (wasLastBehaviorWander)
        {
            aIBehaviorWander.enabled = true;
        }
        else
        {
            aIBehaviorPatrol.enabled = true;
        }
    }
}
