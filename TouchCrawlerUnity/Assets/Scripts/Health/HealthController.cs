using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    /// <summary>
    /// CurrentHealth is the current health of a character. Float because that takes less memory space.
    /// </summary>
    public float CurrentHealth = 100f;
    
    /// <summary>
    /// Each frame, the game will check to see if health is less than or equal to 0. It will crash if Health falls that low.
    /// This is not going to be in the final game, obviously. We don't want it to crash.
    /// </summary>
    private void Update()
    {
       if(CurrentHealth <= 0)
        {
            //throw new System.NotImplementedException();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// TakeDamage is a boolean to verify if an object takes damage. If the method verifies it has, then it returns true.
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    public bool TakeDamage(Damage damage)
    {
        float oldHealth = CurrentHealth;

        float damageAmount = damage.amount;
        CurrentHealth = CurrentHealth - damageAmount;
        
        if(CurrentHealth != oldHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
}
