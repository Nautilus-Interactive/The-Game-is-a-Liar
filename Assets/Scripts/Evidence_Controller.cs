using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence_Controller : MonoBehaviour
{
    public float pickup_distance = 2.0f;

    public bool can_pickup = false;

    private GameObject player;

    private void Start() {
        player = GameObject.Find("Player");    
    }

    private void OnMouseEnter() {
        Debug.Log("Display Info");

        if (can_pickup) {

        }


    }

    private void OnMouseExit() {
        
    }

    private void OnMouseDown() {
        Debug.Log(Vector3.Distance(player.transform.position, this.transform.position));
        Debug.Log("PickUp");
        Global_Functions.add_inventory(this.gameObject);        
        Destroy(this.gameObject);
    }
}
