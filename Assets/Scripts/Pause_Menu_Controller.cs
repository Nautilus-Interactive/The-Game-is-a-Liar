using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Controller : MonoBehaviour
{
    public GameObject pause_menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pause_menu.SetActive(true);
            Game_Variables.pause_game();
        }
    }

    public void Resume() {
        pause_menu.SetActive(false);
        Game_Variables.resume_game();
    }

    public void MainMenu() {
        Debug.Log("Loading Menu Scene...");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
