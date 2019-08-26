using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Evidence_Controller : MonoBehaviour
{
    public float pickup_distance = 3.0f;
    public bool can_pickup = false;
    private GameObject player;
    public string name;
    public GameObject UI;

    private void Start() {
        player = GameObject.Find("Player");
        UI.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;
        UI.transform.Find("Pickup").gameObject.SetActive(can_pickup);
    }

    private void OnMouseOver() {
        Vector3 distance = player.transform.position - this.transform.position;
        if (distance.magnitude < pickup_distance) {
            ShowInfo();
        }
        else {
            HideInfo();
        }
    }

    private void OnMouseExit() {
        HideInfo();
    }

    private void OnMouseDown() {
        Vector3 distance = player.transform.position - this.transform.position;
        if (distance.magnitude < pickup_distance) {
            Pickup();
        }
    }

    void ShowInfo() {
        //Debug.Log("Display Info");
        UI.SetActive(true);
    }

    void HideInfo() {
        //Debug.Log("Display Info");
        UI.SetActive(false);
    }

    void Pickup() {
        Debug.Log("PickUp");
        Global_Functions.add_inventory(this.gameObject);
        Destroy(this.gameObject);
    }
}
