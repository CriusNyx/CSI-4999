using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActor :  NPCActor
{
    public void Update()
    {
        SwitchWeapon();
    }
    void SwitchWeapon()
    {
        Assets.WeaponSystem.Weapon[] allWeapons = GetComponentsInChildren<Assets.WeaponSystem.Weapon>();
        Random random = new Random();
        try
        {
            weapon = allWeapons[(int)Random.Range(0f, allWeapons.Length)];
        }
        catch {
            Debug.Log("Boss doesn't have a weapon");
        }
  
    }
}
