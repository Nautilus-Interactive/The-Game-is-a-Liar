using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory _inventory;
 
    void Start() {
      StartTime();
        _inventory.ItemAdded += ItemAdded;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameObject.Find("PausePanel").SetActive(true);
            StopTime();
        }
    }

    // Methods used for Pause Menu
    public void Resume() {
        GameObject.Find("PausePanel").SetActive(false);
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
            }
        }
    }

    // Methods used for Dialog
    public void ShowDialog() {
        GameObject.Find("DialogPanel").SetActive(true);
    }

    public void HideDialog() {
        GameObject.Find("DialogPanel").SetActive(false);
    }
}
