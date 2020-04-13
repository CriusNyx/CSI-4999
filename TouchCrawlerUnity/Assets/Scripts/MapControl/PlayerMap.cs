using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMap : MonoBehaviour
{
    Camera camera;
    List<RoomController> rooms;
    RoomController currentRoomController;
    MovementController movementController;
    int defaultCameraSize = 5;
    int mapCameraSize = 40;
    public bool showMap = false;
    private bool showLock;
    private bool wereRoomsAdded;
    void Start()
    { 
        showLock = false;
        wereRoomsAdded = false;
        rooms = new List<RoomController>();
        camera = GameObject.Find("GameScenePrefab").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Camera>();
        Debug.Log(camera);
    }

    // Update is called once per frame
    void Update()
    {
        showMap = Input.GetKey(KeyCode.K);
        if (!wereRoomsAdded)
        {
            wereRoomsAdded = AddRooms();
        }
        if (wereRoomsAdded && showMap && !showLock)
        {
            ShowMap();
        }
        else if(!showMap && showLock)
        {
            HideMap();
        }
    }

    private bool AddRooms()
    {
        RoomController[] r = gameObject.GetComponentsInChildren<RoomController>();
        for (int i = 0; i < r.Length; i++)
        {
            rooms.Add(r[i]);
        }
        movementController = GameObject.Find("Player").GetComponent<MovementController>(); //new MovementController(); // GameObject.Find("Player").GetComponent<MovementController>();
        return rooms.Count > 0;
    }

    public void ShowMap()
    {
        //GameObject.Find("Player").GetComponent<MovementController>();
        if (wereRoomsAdded && showMap && !showLock)
        {
            camera.orthographicSize = mapCameraSize;
            Debug.Log("Show");
            System.Action<RoomController> function = MakeRoomVisible;
            rooms.ForEach(function);
            movementController.enabled = false;
            showLock = true;
        }
    }

    private void  MakeRoomVisible(RoomController room)
    {
        Debug.Log(room);
        Debug.Log(room.cleared);
        if (room.isVisible)
        {
            currentRoomController = room;
        }
        if (room.cleared || room == currentRoomController)
        {   
            room.isVisible = true;
        }
        Debug.Log(room.isVisible);
    }

    public void HideMap()
    {
        if (!showMap && showLock)
        {
            camera.orthographicSize = defaultCameraSize;
            for (int i = 0; i < rooms.Count; i++)
            {
                rooms[i].isVisible = false;
            }
            try
            {
                currentRoomController.isVisible = true;
            }
            catch
            {

            }
            movementController.enabled = true;
            showLock = false;
        }
    }
}
