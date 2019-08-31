using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CopCar : MonoBehaviour
{
    public GameObject UI;
    public HUD hud;
    public int evidenceNeeded;

    private bool canAccuse = false;

    private void OnMouseOver() {

        canAccuse = (hud._inventory.EvidenceAmount() + hud._notePad.NoteAmount()) >= evidenceNeeded;
        if (canAccuse) {
            UI.SetActive(true);
        }
    }

    private void OnMouseExit() {
        UI.SetActive(false);
    }

    private void OnMouseUp() {
        if (canAccuse) {
            hud.ShowAccusations();
        }
    }
}
