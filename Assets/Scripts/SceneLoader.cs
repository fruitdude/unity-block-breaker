using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{
    public void LoadNextScene() {
        //gets the index of the current running scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //adds plus 1 to the current scene index
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void loadStartScene() {
        FindObjectOfType<GameSession>().resetScore();
        SceneManager.LoadScene(0);
    }

    public void loadLevel1() {
        FindObjectOfType<GameSession>().resetScore();
        SceneManager.LoadScene(1); 
    }

    public void loadLevel2() {
        FindObjectOfType<GameSession>().resetScore();
        SceneManager.LoadScene(2);
    }

    public void loadLevel3() {
        FindObjectOfType<GameSession>().resetScore();
        SceneManager.LoadScene(3);
    }

    public void quitApplication() {
        Application.Quit();
    }
}
