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
        Light();
    }

    void Flicker()
    {
        StartCoroutine(WaitFlicker());
        StopCoroutine(WaitFlicker());
    }

    IEnumerator WaitFlicker()
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("test WaitLight()");
        var temp = overlay.color;
        temp.a = Random.Range(.5f, 1);
        overlay.color = temp;

        if (on)
        {
            Flicker();
        }
    }



    void Light()
    {
        on = false; //here for relighting, stops Flicker
        StartCoroutine(WaitLight());
        StopCoroutine(WaitLight());
    }

    IEnumerator WaitLight()
    {
        yield return new WaitForSeconds(0.01f);
        Debug.Log("test WaitLight()");
        var temp = overlay.color;
        temp.a += .05f;
        overlay.color = temp;

        if(temp.a <= .95)
        {
            Light();
        } else
        {
            on = true;
            Flicker();
        }
    }

}
