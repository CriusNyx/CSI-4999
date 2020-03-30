using Assets.Scripts.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EffectDot : MonoBehaviour
{

    public int timeSeconds;
    public int ticks;
    public IWeaponTarget target;
    public Damage damage;

    public EffectDot(IWeaponTarget target, int timeSeconds, int ticks, Damage damage)
    {
        this.target = target;
        this.timeSeconds = timeSeconds;
        this.ticks = ticks;
        this.damage = damage;
        StartCoroutine(ApplyDamage());
    }

    IEnumerator ApplyDamage()
    {
        for (int i = 0; i < ticks; i++)
        {
            yield return new WaitForSeconds(timeSeconds / ticks);
            target.DoDamage(damage);
        }

    }
}