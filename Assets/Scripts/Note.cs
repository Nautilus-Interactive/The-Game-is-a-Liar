using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WitnessNote {
    string Name { get; }
    string Note { get; }
    void OnFinishConversation();
}

public class WitnessNoteEventArgs : EventArgs {

    public WitnessNote Note;

    public WitnessNoteEventArgs(WitnessNote note) {
        Note = note;
    }

}
