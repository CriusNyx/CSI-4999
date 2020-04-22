using Assets.Scripts.WeaponSystem;
using Assets.Scripts.WeaponSystem.Components.AccuracyControllers;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrigger : WeaponComponent
{
    public override ComponentType componentType => ComponentType.Trigger;

    public override FireRequestResult RequestFire(Weapon weapon, IWeaponTarget target, FireRequestResult result)
    {
        var myActor = weapon.GetComponentInParent<IActor>();
        var targetActor = target.actor;
        if(myActor != null && targetActor != null)
        {
            Vector3 myPos = myActor.gameObject.transform.position;
            Vector3 targetPos = targetActor.gameObject.transform.position;
            if(Vector3.Distance(myPos, targetPos) < 1.5f)
            {
            }
            else
            {
                myActor.movementController.AttackMove(targetActor, 1.5f);
                result.blockWeaponFire = true;
            }
        }
        

        return result;
    }

    public override FireResult Fire(Weapon weapon, IWeaponTarget target, AccuracyController accuracyController, BulletSpawnInfo bulletSpawnInfo, FireResult result)
    {
        var myActor = weapon.GetComponentInParent<IActor>();
        var targetActor = target.actor;
        if (myActor != null && targetActor != null)
        {
            Vector3 myPos = myActor.gameObject.transform.position;
            Vector3 targetPos = targetActor.gameObject.transform.position;
            if (Vector3.Distance(myPos, targetPos) < 1.5f)
            {
                result.AddProjectile(weapon.CreateProjectile(target, accuracyController, bulletSpawnInfo, 1));
                result.success = true;
            }
            else
            {
                myActor.movementController.Move(targetActor);
            }
        }


        return result;
    }
}