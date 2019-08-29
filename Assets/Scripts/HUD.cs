using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour {
    public Inventory _inventory;
    public Queue<string> _sentences;
    public GameObject DialoguePanel;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI _dialogueText;

    void Start() {
        StartTime();
        _inventory.ItemAdded += ItemAdded;
        _sentences = new Queue<string>();
        DialoguePanel.SetActive(false);
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
    public void StartDialogue(Dialogue dialogue) {
        _name.text = dialogue._name;
        _sentences.Clear();

        foreach (string sentance in dialogue._sentences) {
            _sentences.Enqueue(sentance);
        }

        DisplayNextSentence();
        DialoguePanel.SetActive(true);
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

    public void EndDialogue() {
        DialoguePanel.SetActive(false);
    }

    //Methods used for Notes
    public void ShowNotes() {
        transform.Find("NotesPanel").gameObject.SetActive(true);
    }

    public void HideNotes() {
        transform.Find("NotesPanel").gameObject.SetActive(false);
    }
}
