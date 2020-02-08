using System.Collections;
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

        addRoom(seedRoom);
        
        //neighbor rooms

    }

    void addRoom(GameObject seedRoom)
    {
        RoomController seedRoomCont = seedRoom.GetComponent<RoomController>();
        int totalNeighbors = Random.Range(1, 5); // 1-4
        indexes = new List<int> { 0, 1, 2, 3 };
        Vector3 newPosition = new Vector3(0, 0, 0);
        Debug.Log("neighbors = " + totalNeighbors);

        /*ignore already open doors
        for(int i = 0; i < 4; i++)
        {
            if(seedRoomCont.neighbors[i] != null)
            {
                indexes.RemoveAt(i);
            }
        } */

        List<int> randInd = new List<int>();
        while (indexes.Count > 0)
        {
            int temp = indexes[Random.Range(0, indexes.Count)];
            indexes.Remove(temp);
            //randomized options
            randInd.Add(temp);
        }

        for (int i = 0; i < totalNeighbors; i++)
        {
            if((currNumRooms < finalNumRooms) && (randInd.Count > i))
            {
                //make 1 new room
                GameObject room = Instantiate(roomPrefab);
                room.transform.SetParent(transform.root.gameObject.transform);
                RoomController roomCont = room.GetComponent<RoomController>();

                //set it to root as neighbor
                //seedRoomCont.neighbors[randInd[i]] = room;
                switch (randInd[i])
                {
                    case 0:
                        newPosition = new Vector3(seedRoomCont.gridPosition.x - 1, seedRoomCont.gridPosition.y);
                        //roomCont.neighbors[2] = seedRoom;
                        break;
                    case 1:
                        newPosition = new Vector3(seedRoomCont.gridPosition.x, seedRoomCont.gridPosition.y + 1);
                        //roomCont.neighbors[3] = seedRoom;
                        break;
                    case 2:
                        newPosition = new Vector3(seedRoomCont.gridPosition.x + 1, seedRoomCont.gridPosition.y);
                        //roomCont.neighbors[0] = seedRoom;
                        break;
                    case 3:
                        newPosition = new Vector3(seedRoomCont.gridPosition.x, seedRoomCont.gridPosition.y - 1);
                        //roomCont.neighbors[1] = seedRoom;
                        break;
                }

                if ((System.Math.Abs(newPosition.x) > gridRadius) || (System.Math.Abs(newPosition.y) > gridRadius))
                {
                    Debug.Log("Deleted! New Position = " + newPosition);
                    GameObject.Destroy(room);
                } else
                {
                    bool exists = false;
                    foreach (GameObject roomCheck in roomObjects)
                    {
                        RoomController roomCheckCont = roomCheck.GetComponent<RoomController>();
                        if(roomCheckCont.gridPosition == newPosition)
                        {
                            Debug.Log("Deleted! Overlap position = " + newPosition);
                            GameObject.Destroy(room);
                            exists = true;
                        }
                    }
                    if (!exists)
                    {
                        roomCont.gridPosition = newPosition;
                        currNumRooms++;
                        roomObjects.Add(room);
                    }

                }

                if ((currNumRooms < finalNumRooms) && room != null)
                {
                    addRoom(room);
                }
            }
        }
        


    }

}
