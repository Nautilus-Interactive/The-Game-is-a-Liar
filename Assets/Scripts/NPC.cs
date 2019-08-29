using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, DialogueItem, NoteItem {

    public GameObject UI;

    public string _Name;
    public string Name {
        get {
            return _Name;
        }
    }

    [TextArea(3, 10)]
    public string[] _Senteces;
    public string[] Sentences {
        get {
            return _Senteces;
        }
    }

    [TextArea(3, 10)]
    public string _Note;
    public string Note {
        get {
            return _Note;
        }
    }

    public void OnPickup() {
        return;
    }

    public void OnStartDialogue() {
        GameObject.Find("HUD").GetComponent<HUD>().SetCurrentInteraction(this.gameObject);
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
