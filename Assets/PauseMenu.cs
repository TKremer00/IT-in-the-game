using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        //check if escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape)){ //change Escape to change the key
            if (GameIsPaused){
                Resume();
            } else {
                Pause ();
            }
        }
    }

//Lets the user Resume the game if escape was pressed if the game was paused
    public void Resume () {
        pauseMenuUI.SetActive (false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

//Lets the user pause the game if escape was pressed if the game wasn't paused
    void Pause () {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

//lets the user return to the menu (don't know if nessecary)
    public void LoadMenu () {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene (0);
    }

    //lets the user quit the game (don't know if nessecary)
    public void QuitGame () {
        Debug.Log("Quiting game...");
        Application.Quit();
    }
}
