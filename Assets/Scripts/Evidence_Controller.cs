using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence_Controller : MonoBehaviour
{
    public float pickup_distance = 2.0f;

    private GameObject player;

    private void Start() {
        player = GameObject.Find("Player");    
    }

    private void OnMouseEnter() {
        Debug.Log("Display Info");
    }

    private void OnMouseDown() {
        Debug.Log(Vector3.Distance(player.transform.position, this.transform.position));
        if (Vector3.Distance(player.transform.position, this.transform.position) <= pickup_distance) {
            Debug.Log("PickUp");
            Destroy(this.gameObject);
        }
    }
}
