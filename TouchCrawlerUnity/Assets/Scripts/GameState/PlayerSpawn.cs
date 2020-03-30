using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject ui;

    public static PlayerSpawn instance;

    private void Start()
    {
        if(instance != null)
        {
            Destroy(instance.player);
            Destroy(instance.ui);
            Destroy(instance.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(ui);
        SceneManager.LoadScene("TileTest");
    }
}