using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {
    public float _maxDistance = 1.0f;
    public Inventory Inventory;

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.gameObject.tag == "Interactable") {
                if (Vector3.Distance(hit.transform.position, transform.position) < _maxDistance) {
                    MouseOver(hit.transform.gameObject);
                }
                else {
                    hit.transform.gameObject.SendMessage("Out");
                }
            }
        }
    }

    private void MouseOver(GameObject gameObject) {
        gameObject.SendMessage("Over");
        if (Input.GetMouseButtonUp(0)) {
          Inventory.AddEvicence(gameObject.GetComponent<EvidenceItem>());
        }
    }
}
