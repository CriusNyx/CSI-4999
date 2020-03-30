using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    DoorFlicker roomLight;
    public int doorID;
    public GameObject nextRoom;
    private bool enabledColl;
    private bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        roomLight = transform.GetChild(0).GetComponent<DoorFlicker>();
        nextRoom = transform.parent.GetComponent<RoomController>().neighbors[doorID];
    }

    public void SetEnabled(bool set)
    {
        enabledColl = set;
        //Debug.Log("Setting spawn room doors on - doors to : " + set + "|| is now: " + enabledColl);
    }

    public void SetDoor(bool open)
    {
        if(open)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            enabledColl = true;

        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
            enabledColl = false;
        }
    }

    public void SetDoorLock(bool locked)
    {
        this.locked = locked;
        if(this.locked)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void ToggleLightDoor(bool light)
    {
        if(light)
        {
            roomLight.LightOn();
        }
        else
        {
            roomLight.LightOff();
        }
    }

    //
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && enabledColl && !locked)
        {
            //Debug.Log("Trigger entered!");
            //activate correct neighbor

            //teleport player to correct door spawn
            int newDoor;
            if(doorID > 1)
            {
                newDoor = doorID - 2;
            }
            else
            {
                newDoor = doorID + 2;
            }

            this.GetComponentInParent<RoomController>().OnRoomExit();

            var roomController = nextRoom.GetComponent<RoomController>();
            roomController.EnterDoor(other.GetComponent<IActor>(), newDoor);
            roomController.OnRoomEnter();
            //nextRoom.GetComponent<RoomController>().doorList[newDoor].GetComponent<DoorController>().SetEnabled(false);
            //other.gameObject.GetComponent<MovementController>().Warp(nextRoom.GetComponent<RoomController>().getSpawns(newDoor));

            //set camera target

            //gameObject.transform.parent.gameObject.SetActive(false);            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetComponent<RoomController>().SetDoorColliders(true);
    }

}
