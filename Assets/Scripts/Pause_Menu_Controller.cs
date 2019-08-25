using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Controller : MonoBehaviour
{
    public GameObject pause_menu;
    public GameObject _crosshair;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pause_menu.SetActive(true);
            Global_Functions.pause_game();
        }
    }

    public void Resume() {
        pause_menu.SetActive(false);
        Global_Functions.resume_game();
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
