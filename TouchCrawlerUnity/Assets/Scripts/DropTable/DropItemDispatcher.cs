using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemDispatcher : MonoBehaviour
{
    private int frameNum = 0;
    GameObject drop;

    // Update is called once per frame
    void Update()
    {
        if(frameNum == 2)
        {
            Destroy(gameObject);
            GameObjectFactory.Instantiate(drop, transform.position);
        }
        frameNum++;
    }

    public static DropItemDispatcher Create(GameObject drop, Vector3 position)
    {
        var gameObject = GameObjectFactory.Create("Drop Dispatcher", position);
        var output = gameObject.AddComponent<DropItemDispatcher>();
        output.drop = drop;
        return output;
    }
}
