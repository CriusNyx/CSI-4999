using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    private GameObject[] doorList = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        doorList[0] = this.transform.GetChild(0).gameObject; //west     0
        doorList[1] = this.transform.GetChild(1).gameObject; //north    1
        doorList[2] = this.transform.GetChild(2).gameObject; //east     2
        doorList[3] = this.transform.GetChild(3).gameObject; //south    3
        //doorList[4] = this.transform.GetChild(4).gameObject; //down   4
    }

    void CheckNeighbors()
    {
        //check if neighboring cells have rooms, set doors active
    }


    void ToggleDoorOpen(bool set)
    {
        //child 2, closed door, not yet added
        //true = open
        if (set)
        {
            foreach(GameObject door in doorList)
            {            
                //test if it doesn't like inactive doors    
                door.transform.GetChild(2).gameObject.SetActive(false); //turn door OFF
                door.transform.GetChild(0).gameObject.SetActive(true); //turn trigger collider ON
            }
        }else
        {
            foreach (GameObject door in doorList)
            {
                door.transform.GetChild(2).gameObject.SetActive(true); //turn door ON
                door.transform.GetChild(0).gameObject.SetActive(false); //turn trigger collider OFF
                //check if lit, record, relight after?
            }
        }
        //false = close
    }

    void ToggleDoorLit(bool set, int id)
    {
        //true = on; room explored
        //false = off; room not explored
        if (set)
        {
            doorList[id].transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            doorList[id].transform.GetChild(1).gameObject.SetActive(true);
        }

    }

}
