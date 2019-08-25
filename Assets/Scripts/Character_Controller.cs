using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    CharacterController character_controller;
    public GameObject body;
    public float move_speed = 6.0f;
    public float rotate_speed = 2.0f;

    private Vector3 move_direction = Vector3.zero;
    private Vector3 look_at = Vector3.zero;

    void Start() {
        character_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move_direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * move_speed;
        move_direction.y += Physics.gravity.y * Time.deltaTime;

        character_controller.Move(move_direction * Time.deltaTime);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            Vector3 point = hit.point;
            point.y = body.transform.position.y;
            Vector3 targetDir = point - body.transform.position;

            float step = rotate_speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            body.transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
