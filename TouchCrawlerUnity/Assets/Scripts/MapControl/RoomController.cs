using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject[] doorList = new GameObject[5];
    public GameObject[] neighbors = new GameObject[4];
    private GameObject[] playerSpawns = new GameObject[4];
    public CameraTarget CameraTarget { get; private set; }

    public int neighborCount;
    public bool cleared;
    public Vector3 gridPosition;

    private GameObject fog;
    private Material fogMaterial;
    private bool isVisable = false;

    void Awake()
    {
        cleared = false;
        CameraTarget = gameObject.AddComponent<CameraTarget>();
        fog = GameObject.CreatePrimitive(PrimitiveType.Quad);
        fog.transform.parent = transform;
        fog.transform.localPosition = new Vector3(2, 1, -1f);
        fog.transform.localScale = new Vector3(16.1f, 12.1f, 1);
        Destroy(fog.GetComponent<MeshCollider>());
        fogMaterial = Instantiate(Resources.Load<Material>("Material/Fog"));
        fog.GetComponent<MeshRenderer>().material = fogMaterial;
    }

    private void Update()
    {
        Color temp = fogMaterial.color;
        if(isVisable)
        {
            temp.a = Mathf.MoveTowards(temp.a, 0f, Time.deltaTime * 2f);
        }
        else
        {
            temp.a = Mathf.MoveTowards(temp.a, 1f, Time.deltaTime * 2f);
        }
        fogMaterial.color = temp;
    }

    public void setPosition()
    {
        transform.position =
            new Vector3(
                (gridPosition.x * 16),
                (gridPosition.y * 12),
                0);
    }


    public void SetDoorColliders(bool set)
    {
        foreach(GameObject door in doorList)
        {
            //Debug.Log("Setting doors enabled - room");
            door.GetComponent<DoorController>().SetEnabled(set);
        }
    }


    public void CheckNeighborDoors()
    {
        ////check if neighboring cells have rooms, set doors active
        //for(int i = 0; i < 5; i++)
        //{
        //    //Debug.Log("Locating Neighbor " + i);
        //    doorList[i] = transform.GetChild(i + 2).gameObject;
        //    if(i < 4)
        //    {
        //        playerSpawns[i] = transform.Find("PlayerSpawns").GetChild(i).gameObject;
        //    }

        //    //west = 0, north = 1, east = 2, south = 3, down = 4
        //    doorList[i].SetActive(false);
        //}


        foreach(Transform child in transform)
        {
            switch(child.name)
            {
                case "door_1000":
                    doorList[0] = child.gameObject;
                    break;
                case "door_0100":
                    doorList[1] = child.gameObject;
                    break;
                case "door_0010":
                    doorList[2] = child.gameObject;
                    break;
                case "door_0001":
                    doorList[3] = child.gameObject;
                    break;
                case "door_down":
                    doorList[4] = child.gameObject;
                    break;
            }
        }

        for(int i = 0; i < 5; i++)
        {
            if(i < 4)
            {
                playerSpawns[i] = transform.Find("PlayerSpawns").GetChild(i).gameObject;
            }

            doorList[i].SetActive(false);
        }

        for(int i = 0; i < 4; i++)
        {
            //doorList[0].SetActive(true);
            if(neighbors[i] != null)
            {
                doorList[i].SetActive(true);
            }
        }
    }

    public Vector3 getSpawns(int index)
    {
        return playerSpawns[index].transform.position;
    }

    public void ToggleDoorOpen(int id, bool open)
    {
        doorList[id].GetComponent<DoorController>().SetDoor(open);
        SetDoorColliders(open);
    }


    public void ToggleDoorLit(bool set, int id)
    {
        doorList[id].GetComponent<DoorController>().ToggleLightDoor(set);
    }

    public void OnRoomEnter(bool? cleared = null)
    {
        isVisable = true;

        if(cleared != null)
        {
            this.cleared = cleared.Value;
        }

        if(!this.cleared)
        {
            WeightedRandomSelector<SpawnSet> randomSelector = new WeightedRandomSelector<SpawnSet>();
            foreach(var spawn in gameObject.GetComponentsInChildren<SpawnSet>())
            {
                randomSelector.Add(spawn, spawn.weight);
            }
            var spawner = randomSelector.Select(Random.value);
            var spawnPoints = spawner.GetComponentsInChildren<SpawnPoint>();
            if(spawnPoints.Length > 0)
            {
                EnemyTracker tracker = gameObject.EnsureComponent<EnemyTracker>();
                tracker.OnEmpty += Clear;

                foreach(var spawnPoint in spawner.GetComponentsInChildren<SpawnPoint>())
                {
                    tracker.Track(spawnPoint.Spawn());
                }
                foreach(var door in doorList)
                {
                    if(door != null)
                    {
                        door.GetComponent<DoorController>()?.SetDoorLock(true);
                    }
                }

                tracker.Trip();
            }
        }
    }

    public void Clear()
    {
        cleared = true;
        foreach(var door in doorList)
        {
            if(door != null)
            {
                door.GetComponent<DoorController>()?.SetDoorLock(false);
            }
        }
    }

    public void OnRoomExit()
    {
        isVisable = false;
    }

    public void EnterDoor(IActor actor, int doorIndex)
    {
        var door = doorList[doorIndex];
        door.GetComponent<DoorController>().SetEnabled(false);
        actor.movementController.Warp(getSpawns(doorIndex));
        actor.OnRoomEnter(this);
    }

    private void OnDestroy()
    {
        Destroy(fogMaterial);
    }
}
