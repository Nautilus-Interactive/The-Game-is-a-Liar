using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject UI;

    void Start() {
      StartTime();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UI.SetActive(true);
            StopTime();
        }
    }

    public void Resume() {
        UI.SetActive(false);
        StartTime();
    }

    public void MainMenu() {
        Debug.Log("Loading Menu Scene...");
        StartTime();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    private void StopTime() {
      Time.timeScale = 0;
    }

    private void StartTime() {
      Time.timeScale = 1;
    }
}
