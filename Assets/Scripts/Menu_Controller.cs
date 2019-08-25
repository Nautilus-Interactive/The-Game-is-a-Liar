using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public GameObject credits;
    public void StartGame() {
        Debug.Log("Loading Game Scene...");
        Game_Variables.start_game();
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
