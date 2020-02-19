using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    private GameObject[] doorList = new GameObject[5];
    public GameObject[] neighbors = new GameObject[4];
    public int neighborCount;
    public bool cleared;
    public Vector3 gridPosition;

    void Start()
    {
        cleared = false;
    }

    public void setPosition()
    {
        transform.position = new Vector3((gridPosition.x * 16)
            , (gridPosition.y * 12), 0);
    }


    public void CheckNeighborDoors()
    {
        for (int i = 0; i < 5; i++)
        {
            doorList[i] = transform.GetChild(i + 2).gameObject;
            //west = 0, north = 1, east = 2, south = 3, down = 4
            doorList[i].SetActive(false);
        }

        //check if neighboring cells have rooms, set doors active
        for (int i = 0; i < 4; i++)
        {
            //doorList[0].SetActive(true);
            if (neighbors[i] != null)
            {
                doorList[i].SetActive(true);
            }
        }
    }


    public void ToggleDoorOpen(int id, bool open)
    {
        doorList[id].GetComponent<DoorController>().ToggleDoor(open);
    }


    public void ToggleDoorLit(bool set, int id)
    {
        doorList[id].GetComponent<DoorController>().ToggleLightDoor(set);
    }

    public void OnRoomEnter()
    {
        WeightedRandomSelector<SpawnSet> randomSelector = new WeightedRandomSelector<SpawnSet>();
        foreach(var spawn in gameObject.GetComponentsInChildren<SpawnSet>())
        {
            randomSelector.Add(spawn, spawn.weight);
        }
        var spawner = randomSelector.Select(Random.value);
        foreach(var spawnPoint in spawner.GetComponentsInChildren<SpawnPoint>())
        {
            spawnPoint.Spawn();
        }
    }
}
