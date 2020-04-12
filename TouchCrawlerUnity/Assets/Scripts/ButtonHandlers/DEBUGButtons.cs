using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEBUGButtons : MonoBehaviour
{
    public Text text;

    public void SetDebug()
    {
        text.text = UserCredentials.token + "\n" + UserCredentials.name;
    }
}
