using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour {
    public Inventory _inventory;
    public Dialogue _dialogue;
    public NotePad _notePad;

    public Queue<string> _sentences;
    public TextMeshProUGUI _dialogueName;
    public TextMeshProUGUI _dialogueText;
    public TextMeshProUGUI _notesText;

    public GameObject _talkingTo;

    void Start() {
        _inventory.ItemAdded += ItemAdded;
        _dialogue.DialogueStarted += DialogueStarted;
        _notePad.NoteAdded += NoteAdded;

        _notesText.text = "";
        _sentences = new Queue<string>();
        StartTime();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            transform.Find("PausePanel").gameObject.SetActive(true);
            StopTime();
        }
    }

    // Methods used for Pause Menu
    public void Resume() {
        transform.Find("PausePanel").gameObject.SetActive(false);
        StartTime();
    }

    public void MainMenu() {
        Debug.Log("Loading Menu Scene...");
        StartTime();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    private void StopTime() {
        Time.timeScale = 0;
    }

    private void StartTime() {
        Time.timeScale = 1;
    }

    // Methods used for Inventory
    private void ItemAdded(object sender, InventoryItemEventArgs e) {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in inventoryPanel) {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if (!image.enabled) {
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }

    // Methods used for Dialog
    private void DialogueStarted(object sender, DialogueItemEventArgs e) {
        _dialogueName.text = e.Dialogue.Name;
        _sentences.Clear();

        foreach (string sentance in e.Dialogue.Sentences) {
            _sentences.Enqueue(sentance);
        }

        DisplayNextSentence();
        transform.Find("DialoguePanel").gameObject.SetActive(true);
    }

    public void DisplayNextSentence() {
        if (_sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        _dialogueText.text = "";

        foreach (char c in sentence.ToCharArray()) {
            _dialogueText.text += c;
            yield return null;
        }
    }

    public void SetCurrentInteraction(GameObject target) {
        _talkingTo = target;
    }

    public void EndDialogue() {
        transform.Find("DialoguePanel").gameObject.SetActive(false);
        Debug.Log(_talkingTo);
        NoteItem note = _talkingTo.GetComponent<NoteItem>();
        if (note != null) {
            _notePad.AddNote(note);
        }
    }

    //Methods used for Notes
    private void NoteAdded(object sender, NoteItemEventArgs e) {
        string note = e.Note.Name;
        note += "\n" + e.Note.Note;
        _notesText.text += note;
    }

    public void ShowNotes() {
        transform.Find("NotesPanel").gameObject.SetActive(true);
    }

    public void HideNotes() {
        transform.Find("NotesPanel").gameObject.SetActive(false);
    }
}
