using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Controller : MonoBehaviour
{
    public float max_distance = 3.0f;

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.gameObject.tag == "Interactable") {
                Debug.Log("hit");
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }
}
