using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Object : MonoBehaviour
{
    public string name;
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

    public void Click() {
        Global_Functions.add_inventory(this.gameObject);
        Destroy(this.gameObject);
    }
}
