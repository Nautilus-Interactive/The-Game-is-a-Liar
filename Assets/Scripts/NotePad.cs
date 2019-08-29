using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePad : MonoBehaviour
{
    public List<WitnessNote> collectedNotes = new List<WitnessNote>();

    public event EventHandler<WitnessNoteEventArgs> NoteAdded;

    public void AddNote(WitnessNote note) {
        if (!collectedNotes.Contains(note)) {
            collectedNotes.Add(note);
            note.OnFinishConversation();

            if (NoteAdded != null) {
                NoteAdded(this, new WitnessNoteEventArgs(note));
            }
        }
    }
}
