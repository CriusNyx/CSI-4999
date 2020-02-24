using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    DoorFlicker roomLight;
    public int roomID;
    GameObject nextRoom;
    // Start is called before the first frame update
    void Start()
    {
        roomLight = transform.GetChild(0).GetComponent<DoorFlicker>();
        nextRoom = transform.parent.GetComponent<RoomController>().neighbors[roomID];
    }

    public void ToggleDoor(bool open)
    {
        if (open)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetComponent<BoxCollider2D>().enabled = true;

        } else
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void ToggleLightDoor(bool light)
    {
        if (light)
        {
            roomLight.LightOn();
        } else
        {
            roomLight.LightOff();
        }
    }

    //
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //activate correct neighbor
            nextRoom.SetActive(true);

            //teleport player to correct door spawn
            other.gameObject.transform.position = nextRoom.GetComponent<RoomController>().getSpawns(roomID);

            //set camera target

            gameObject.SetActive(false);            

        }
    }

}
