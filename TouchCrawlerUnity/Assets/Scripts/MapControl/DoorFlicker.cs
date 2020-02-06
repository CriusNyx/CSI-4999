using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorFlicker : MonoBehaviour
{
    private Tilemap overlay;
    private bool on;
    
    void Start()
    {
        on = false;
        overlay = GetComponent<Tilemap>();
        LightOn();
    }

    //Set graphic alpha to 0
    //likely unnecessary, we'll just deactivate/reactivate object as needed
    void LightOff()
    {
        on = false;
        var temp = overlay.color;
        temp.a = 0;
        overlay.color = temp;
    }

    void LightOn()
        Light();
    }

    void Flicker()
    {
        StartCoroutine(WaitFlicker());
        StopCoroutine(WaitFlicker());
    }


    //pause .01 seconds, increase graphic alpha by 5%
    //loops until alpha is 100% and the door is "lit"
    //start flicker animation
    IEnumerator WaitLight()
    {
        yield return new WaitForSeconds(0.01f);
        Debug.Log("test WaitLight()");
        var temp = overlay.color;
        temp.a += .05f;
        overlay.color = temp;

        if(temp.a <= .95)
        {
            LightOn();
        } else
        {
            on = true;
            Flicker();
        }
    }


    void Flicker()
    {
        StartCoroutine(WaitFlicker());
        StopCoroutine(WaitFlicker());
    }

    //continues forever, unless the door light goes off
    //ex: when the door is closed, flip to on = false
    //randomly pick a value between 50% and 100% for alpha every .05 seconds
    IEnumerator WaitFlicker()
    {
        yield return new WaitForSeconds(0.05f);
        var temp = overlay.color;
        temp.a = Random.Range(.5f, 1);
        overlay.color = temp;

        if (on)
        {
            Flicker();
        }
    }
}
