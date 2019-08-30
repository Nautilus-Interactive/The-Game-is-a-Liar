﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour, InventoryItem {

    public GameObject UI;

    public string _Name;
    public string Name {
        get {
            return _Name;
        }
    }

    [TextArea(3, 10)]
    public string _Description;
    public string Description {
        get {
            return _Description;
        }
    }

    public Sprite _Image;
    public Sprite Image {
        get {
            return _Image;
        }
    }

    public void OnPickup() {
        Destroy(this.gameObject);
    }

    // Functions for object UI
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
