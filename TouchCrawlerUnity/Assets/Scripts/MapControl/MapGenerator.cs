﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public int minRoomAmount;
    public int maxRoomAmount;
    public int gridRadius;

    private List<GameObject> roomObjects = new List<GameObject>();
    private int currNumRooms;
    private int finalNumRooms;
    private List<int> indexes;
    private Queue<GameObject> nextToAdd = new Queue<GameObject>();

    void Start()
    {
        finalNumRooms = Random.Range(minRoomAmount, maxRoomAmount+1);
        //Origin point
        GameObject seedRoom = Instantiate(roomPrefab);
        seedRoom.transform.SetParent(transform.root.gameObject.transform);
        RoomController seedRoomCont = seedRoom.GetComponent<RoomController>();

        seedRoomCont.gridPosition = new Vector3(0,0,0);
        roomObjects.Add(seedRoom);

        currNumRooms = 1;

        nextToAdd.Enqueue(seedRoom);
        AddRoom(Random.Range(2,5));
        RoomKill();
        FindNeighbors(roomObjects[0]); //closest to origin room
        HangingRoomKill();

        foreach (GameObject room in roomObjects)
        {
            room.GetComponent<RoomController>().CheckNeighborDoors();
        }

        //neighbor rooms

    }

    void AddRoom(int forceNeighbors = 0)
    {
        GameObject seedRoom = nextToAdd.Dequeue();
        RoomController seedRoomCont = seedRoom.GetComponent<RoomController>();
        int totalNeighbors = Random.Range(2, 5); // 2-4

        if(forceNeighbors > 0)
        {
            totalNeighbors = forceNeighbors;
        }

        //check for existing neighbors
        foreach(GameObject checkRoom in roomObjects)
        {
            // neighbor exist?
            if ((System.Math.Abs(checkRoom.GetComponent<RoomController>().gridPosition.x) - (System.Math.Abs(seedRoom.GetComponent<RoomController>().gridPosition.x)) == 1)
                || (System.Math.Abs(checkRoom.GetComponent<RoomController>().gridPosition.y) - (System.Math.Abs(seedRoom.GetComponent<RoomController>().gridPosition.y)) == 1)){
                totalNeighbors = System.Math.Max(totalNeighbors--, 0);
            }
        }



        //Debug.Log("Neighbors to add:" + totalNeighbors);

        indexes = new List<int> { 0, 1, 2, 3 };
        Vector3 newPosition = new Vector3(0, 0, 0);


        List<int> randInd = new List<int>();
        //randomize possible neighbors
        while (indexes.Count > 0)
        {
            int temp = indexes[Random.Range(0, indexes.Count)];
            indexes.Remove(temp);
            //randomized options
            randInd.Add(temp);
        }

        for (int i = 0; i < totalNeighbors; i++)
        {
            if(currNumRooms < finalNumRooms)
            {
                //make 1 new room
                GameObject room = Instantiate(roomPrefab);
                room.transform.SetParent(transform.root.gameObject.transform);
                RoomController roomCont = room.GetComponent<RoomController>();

                //Pick random neighbor location
                switch (randInd[i])
                {
                    case 0:
                        newPosition = new Vector3(seedRoomCont.gridPosition.x - 1, seedRoomCont.gridPosition.y);
                        break;
                    case 1:
                        newPosition = new Vector3(seedRoomCont.gridPosition.x, seedRoomCont.gridPosition.y + 1);
                        break;
                    case 2:
                        newPosition = new Vector3(seedRoomCont.gridPosition.x + 1, seedRoomCont.gridPosition.y);
                        break;
                    case 3:
                        newPosition = new Vector3(seedRoomCont.gridPosition.x, seedRoomCont.gridPosition.y - 1);
                        break;
                }

                if ((System.Math.Abs(newPosition.x) > gridRadius) || (System.Math.Abs(newPosition.y) > gridRadius))
                {
                    // outside of grid
                    GameObject.Destroy(room);
                    totalNeighbors = System.Math.Max(4, totalNeighbors++);
                } else
                {
                    bool exists = false;
                    foreach (GameObject roomCheck in roomObjects)
                    {
                        RoomController roomCheckCont = roomCheck.GetComponent<RoomController>();
                        if(roomCheckCont.gridPosition == newPosition)
                        {
                            //room exists here already
                            GameObject.Destroy(room);
                            totalNeighbors = System.Math.Max(4, totalNeighbors++);
                            exists = true;
                        }
                    }
                    if (!exists)
                    {
                        //all good, add the room
                        roomCont.gridPosition = newPosition;
                        roomCont.setPosition();
                        currNumRooms++;
                        nextToAdd.Enqueue(room);
                        roomObjects.Add(room);

                    }
                }
            }
        }

        if ((currNumRooms < finalNumRooms) && nextToAdd.Count > 0)
        {
            //FOR NEXT IN QUEUE
            AddRoom();
        }


    }

    //add some more variability
    void RoomKill()
    {
        for(int i = 0; i < roomObjects.Count*.25; i++)
        {
            int rand = Random.Range(1, roomObjects.Count - 1);
            GameObject temp = roomObjects[rand];
            roomObjects.Remove(roomObjects[rand]);
            GameObject.Destroy(temp);

        }
    }


    //takes no input, makes sure all rooms are reachable from the origin point
    void HangingRoomKill()
    {
        for(int i = 0; i < roomObjects.Count; i++)
        {
            if (roomObjects[i].GetComponent<RoomController>().neighborCount == 0)
            {
                GameObject temp = roomObjects[i];
                roomObjects.Remove(roomObjects[i]);
                GameObject.Destroy(temp);
                i--; //list is smaller
            }
        }
    }

    //start from origin (called in start) and as neighbors are found, they, in turn, find their neighbors
    void FindNeighbors(GameObject seedRoom)
    {
        foreach (GameObject checkRoom in roomObjects)
        {
            int xDiff = (int)(seedRoom.GetComponent<RoomController>().gridPosition.x - checkRoom.GetComponent<RoomController>().gridPosition.x);
            int yDiff = (int)(seedRoom.GetComponent<RoomController>().gridPosition.y - checkRoom.GetComponent<RoomController>().gridPosition.y);

            RoomController seedCont = seedRoom.GetComponent<RoomController>();
            RoomController neighborCont = checkRoom.GetComponent<RoomController>();

            switch (xDiff.ToString() + yDiff.ToString())
            {
                case "01":
                    //without internal if check, will constantly call its already found neighbors
                    if(seedCont.neighbors[3] != checkRoom)
                    {
                        seedCont.neighbors[3] = checkRoom;
                        seedCont.neighborCount++;
                        neighborCont.neighbors[1] = seedRoom;
                        neighborCont.neighborCount++;
                        FindNeighbors(checkRoom);
                    }
                    break;

                case "0-1":
                    if (seedCont.neighbors[1] != checkRoom)
                    {
                        seedCont.neighbors[1] = checkRoom;
                        seedCont.neighborCount++;
                        neighborCont.neighbors[3] = seedRoom;
                        neighborCont.neighborCount++;
                        FindNeighbors(checkRoom);
                    }
                    
                    break;

                case "10":
                    if (seedCont.neighbors[0] != checkRoom)
                    {
                        seedCont.neighbors[0] = checkRoom;
                        seedCont.neighborCount++;
                        neighborCont.neighbors[2] = seedRoom;
                        neighborCont.neighborCount++;
                        FindNeighbors(checkRoom);
                    }
                        
                    break;

                case "-10":
                    if (seedCont.neighbors[2] != checkRoom)
                    {
                        seedCont.neighbors[2] = checkRoom;
                        seedCont.neighborCount++;
                        neighborCont.neighbors[0] = seedRoom;
                        neighborCont.neighborCount++;
                        FindNeighbors(checkRoom);
                    }
                        
                    break;

            }

        }

    
    }


}