using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceItem : MonoBehaviour, InventoryItem {

    public GameObject UI;

    public void Start() {
        UI.SetActive(false);
    }

    // Called by the mouse ray when inside range
    public void Over() {
        UI.SetActive(true);
    }

    // Called by the mouse ray when outside range
    public void Out() {
        UI.SetActive(false);
    }

    // Called when the mouse moves outside the object
    public void OnMouseExit() {
        UI.SetActive(false);
    }

}
