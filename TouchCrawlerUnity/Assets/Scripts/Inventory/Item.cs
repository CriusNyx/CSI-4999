using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ITouchable
{
    public float focusRadius = 2f;
    private GameObject player;

    public IEvent GetEvent()
    {
        return new ItemTouchInputEvent(this);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (focusRadius >= Vector3.Distance(transform.position, player.transform.position))
        {
            //Debug.Log("Player Nearby");
        }
    }
}
