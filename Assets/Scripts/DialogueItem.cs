using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueSentence {
    public bool Player;
    [TextArea(3, 10)]
    public string Text;
}

public interface DialogueItem {
    string Name { get; }
    DialogueSentence[] Sentences { get; }
    void OnStartDialogue();
}

public class DialogueItemEventArgs : EventArgs {

    public DialogueItem Dialogue;

    public DialogueItemEventArgs(DialogueItem dialogue) {
        Dialogue = dialogue;
    }

}
