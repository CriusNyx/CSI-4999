using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDevice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mobile()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            Destroy(ExitButton);
        }
    }
}
