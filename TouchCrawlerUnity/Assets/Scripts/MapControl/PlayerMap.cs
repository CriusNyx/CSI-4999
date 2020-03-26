using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMap : MonoBehaviour
{
    Camera camera;
    List<RoomController> rooms;
    RoomController currentRoomController;
    int defaultCameraSize = 5;
    int mapCameraSize = 20;
    public bool showMap = false;
    private bool showLock;
    private bool wereRoomsAdded;
    void Awake()
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
        if (!wereRoomsAdded)
        {
            wereRoomsAdded = AddRooms();
        }
        if (wereRoomsAdded && showMap && !showLock)
        {
            ShowMap();
            showLock = true;
        }
        else if(!showMap && showLock)
        {
            HideMap();
            showLock = false;
        }
    }

    private bool AddRooms()
    {
        RoomController[] r = gameObject.GetComponentsInChildren<RoomController>();
        for (int i = 0; i < r.Length; i++)
        {
            rooms.Add(r[i]);
        }
        Debug.Log(rooms.Count);
        return rooms.Count > 0;
    }

    private void ShowMap()
    {
        camera.orthographicSize = mapCameraSize;
        Debug.Log("Show");
        System.Action<RoomController> function = MakeRoomVisible;
        rooms.ForEach(function);
    }

    private void  MakeRoomVisible(RoomController room)
    {
        Debug.Log(room);
        Debug.Log(room.cleared);
        if (room.cleared)
        {
            if (room.isVisible)
            {
                currentRoomController = room;
            }
            room.isVisible = true;
        }
        Debug.Log(room.isVisible);
    }

    private void HideMap()
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
    }
}
