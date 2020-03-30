using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections;

public class TestButtonHandler : MonoBehaviour
{
    public SceneField MainMenuScene;
    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
    }
}
