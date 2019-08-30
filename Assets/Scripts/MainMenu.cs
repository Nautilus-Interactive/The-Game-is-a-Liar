using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject credits;
    public GameObject options;

    public void StartGame() {
        Debug.Log("Loading Game Scene...");
        SceneManager.LoadScene("Game");
    }

    // Options Screen Methods
    public void ShowOptions() {
        Debug.Log("Loading Options Panel...");
        HideCredits();
        options.SetActive(true);
    }

    public void HideOptions() {
        Debug.Log("Loading Options Panel...");
        options.SetActive(false);
    }

    // Credits Screen Methods
    public void ShowCredits() {
        Debug.Log("Loading Credit Panel...");
        HideOptions();
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
