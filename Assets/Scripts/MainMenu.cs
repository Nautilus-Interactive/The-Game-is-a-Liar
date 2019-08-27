using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;

    public void StartGame() {
        Debug.Log("Loading Game Scene...");
        SceneManager.LoadScene("Game");
    }

    public void ShowCredits() {
        Debug.Log("Loading Credit Panel...");
        credits.SetActive(true);
    }

    public void HideCredits() {
        Debug.Log("Loading Credit Panel...");
        credits.SetActive(false);
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
