using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponDebugInputSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            var weapon = GetComponent<Weapon>();
            var result = weapon.Fire(null);
            Debug.Log("fire = " + result.ToString() + " count = " + result.projectiles.Count());
        }
    }
}
