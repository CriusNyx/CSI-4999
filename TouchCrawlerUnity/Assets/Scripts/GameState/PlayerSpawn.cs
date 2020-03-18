using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject ui;

    private void Start()
    {
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(ui);
        SceneManager.LoadScene("TileTest");
    }
}