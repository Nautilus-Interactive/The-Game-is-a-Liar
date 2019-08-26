using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Controller : MonoBehaviour {
    public float max_distance = 1.0f;

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.gameObject.tag == "Interactable") {
                if (Vector3.Distance(hit.transform.position, transform.position) < max_distance) {
                    MouseOver(hit.transform.gameObject);
                }
            }
        }
    }

    void MouseOver(GameObject over) {
        if (Input.GetMouseButtonUp(0)) {
            Pickup(over);
        }
    }

    void Pickup(GameObject over) {
        Global_Functions.add_inventory(over);
        Destroy(over);
    }
}
