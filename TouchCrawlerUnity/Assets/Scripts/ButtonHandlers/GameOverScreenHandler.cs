using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections;

public class GameOverScreenHandler : MonoBehaviour
{

    public SceneField MainMenuScene;
    public SceneField NewGameScene;
    public SceneField LeaderboardScene;

    public void ExitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void MainMenu() {
        SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
    }

    public void Leaderboard() {
        SceneManager.LoadScene(LeaderboardScene, LoadSceneMode.Single);
    }

    public void NewGame() {
        SceneManager.LoadScene(NewGameScene, LoadSceneMode.Single);
    }

    public void SubmitScore()
    {
        GoogleSignInDemo demo = new GoogleSignInDemo();
        demo.SignInWithGoogle();
    }
}