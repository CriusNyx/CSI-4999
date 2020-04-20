using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public SceneField MainMenuScene;
    public Slider sliderSfx;
    public Slider sliderMusic;
    public InputField username;
    public Text debug;

    void Start()
    {
        sliderSfx.onValueChanged.AddListener((x) => { UserSettings.sfxVolume = x; });
        sliderMusic.onValueChanged.AddListener((x) => { UserSettings.musicVolume = x; });
        username.onValueChanged.AddListener((x) => { UserSettings.username = x;});
        username.text = UserSettings.username;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
    }
}
