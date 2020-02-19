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


    //Actor components
    private AIBehaviorPatrol aIBehaviorPatrol;
    private AIBehaviorWander aIBehaviorWander;
    private AIBehaviorAttack aIBehaviorAttack;
    private Rigidbody2D body;
    private MovementController movementController;
    private NPCActor npcActor;
    

    void Start()
    {
        movementController = GetComponent<MovementController>();
        stopTime = 0;
        aIBehaviorAttack = GetComponent<AIBehaviorAttack>();
        aIBehaviorPatrol = GetComponent<AIBehaviorPatrol>();
        aIBehaviorWander = GetComponent<AIBehaviorWander>();
        npcActor = GetComponent<NPCActor>();
        body = GetComponent<Rigidbody2D>();

        if (aIBehaviorWander.enabled && aIBehaviorPatrol.enabled && aIBehaviorAttack.enabled)
        {
            aIBehaviorWander.enabled = true;
            aIBehaviorPatrol.enabled = false;
            aIBehaviorAttack.enabled = false;
        }
        if((aIBehaviorWander.enabled || aIBehaviorPatrol.enabled) && aIBehaviorAttack.enabled)
        {
            aIBehaviorAttack.enabled = false;
        }
        if (aIBehaviorWander.enabled && aIBehaviorPatrol.enabled)
        {
            aIBehaviorPatrol.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (WasAttackedYet())
        {
            StartAttacking();
        }
    }
    





    private bool WasAttackedYet()
    {
        return npcActor.attacker != null;
    }

    private void StartAttacking()
    {
        aIBehaviorAttack.enabled = true;
        aIBehaviorPatrol.enabled = false;
        aIBehaviorWander.enabled = false;
    }
}
