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
        FindNeighbors();

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



        Debug.Log("Neighbors to add:" + totalNeighbors);

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
                    Debug.Log("Deleted! New Position = " + newPosition);
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
                            Debug.Log("Deleted! Overlap position = " + newPosition);
                            GameObject.Destroy(room);
                            totalNeighbors = System.Math.Max(4, totalNeighbors++);
                            exists = true;
                        }
                    }
                    if (!exists)
                    {
                        Debug.Log("Success! Added to Queue as Neighbor: " + i);
                        roomCont.gridPosition = newPosition;
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

    void FindNeighbors()
    {
        //seed
        for(int i = 0; i < roomObjects.Count; i++)
        {
            //neighbor
            for(int j = i; j < roomObjects.Count; j++)
            {
                int xDiff = (int)(roomObjects[i].GetComponent<RoomController>().gridPosition.x - roomObjects[j].GetComponent<RoomController>().gridPosition.x);
                int yDiff = (int)(roomObjects[i].GetComponent<RoomController>().gridPosition.y - roomObjects[j].GetComponent<RoomController>().gridPosition.y);
                RoomController seedCont = roomObjects[i].GetComponent<RoomController>();
                RoomController neighborCont = roomObjects[j].GetComponent<RoomController>();
                //Debug.Log(xDiff.ToString() + yDiff.ToString());

                switch (xDiff.ToString() + yDiff.ToString()) {
                    case "01":  seedCont.neighbors[3] = roomObjects[j];
                                seedCont.neighborCount++;
                                neighborCont.neighbors[1] = roomObjects[i];
                                neighborCont.neighborCount++;
                        break;

                    case "0-1": seedCont.neighbors[1] = roomObjects[j];
                                seedCont.neighborCount++;
                                neighborCont.neighbors[3] = roomObjects[i];
                                neighborCont.neighborCount++;
                        break;

                    case "10":  seedCont.neighbors[0] = roomObjects[j];
                                seedCont.neighborCount++;
                                neighborCont.neighbors[2] = roomObjects[i];
                                neighborCont.neighborCount++;
                        break;

                    case "-10": seedCont.neighbors[2] = roomObjects[j];
                                seedCont.neighborCount++;
                                neighborCont.neighbors[0] = roomObjects[i];
                                neighborCont.neighborCount++;
                        break;

                }

            }

            //Debug.Log(roomObjects[i].GetComponent<RoomController>().neighbors == null);
            if (roomObjects[i].GetComponent<RoomController>().neighborCount == 0)
            {
                Debug.Log("Remove hanging room");
                GameObject temp = roomObjects[i];
                roomObjects.Remove(roomObjects[i]);
                GameObject.Destroy(temp);
                i--; //list is smaller
            }

        }




    }


}
