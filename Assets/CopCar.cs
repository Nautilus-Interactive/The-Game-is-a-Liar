using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CopCar : MonoBehaviour
{
    public GameObject UI;
    public HUD hud;

    private void OnMouseOver() {
        UI.SetActive(true);
    }

    private void OnMouseExit() {
        UI.SetActive(false);
    }

    private void OnMouseUp() {
        hud.ShowAccusations();
    }
}
