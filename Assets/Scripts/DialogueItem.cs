using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DialogueItem {
    string Name { get; }
    string[] Sentences { get; }
    void OnStartDialogue();
}

public class DialogueItemEventArgs : EventArgs {

    public DialogueItem Dialogue;

    public DialogueItemEventArgs(DialogueItem dialogue) {
        Dialogue = dialogue;
    }

}
