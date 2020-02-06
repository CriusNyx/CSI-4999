using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    private GameObject[] doorList = new GameObject[5];
    public bool cleared;

    // Start is called before the first frame update
    void Start()
    {
        cleared = false;
        for (int i = 0; i < 5; i++)
        {
            doorList[i] = this.transform.GetChild(i).gameObject;
            //west = 0, north = 1, east = 2, south = 3, down = 4
        }
    }

    void CheckNeighbors()
    {
        //check if neighboring cells have rooms, set doors active
    }


    void ToggleDoorOpen(bool set)
    {
        
        if (set)
        {
            //true = open
            foreach (GameObject door in doorList)
            {            
                //test if it doesn't like inactive doors    
                door.transform.GetChild(2).gameObject.SetActive(false); //turn door OFF
                door.transform.GetChild(0).gameObject.SetActive(true); //turn trigger collider ON
                //cleared is only open condition?
                cleared = true;
            }
        }else
        {
            //false = close
            foreach (GameObject door in doorList)
            {
                door.transform.GetChild(2).gameObject.SetActive(true); //turn door ON
                door.transform.GetChild(0).gameObject.SetActive(false); //turn trigger collider OFF
                //check if lit, record, relight after?
            }
        }
        
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
            doorList[id].transform.GetChild(1).gameObject.SetActive(false);
        }

    }

}
