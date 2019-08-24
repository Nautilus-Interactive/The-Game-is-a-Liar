using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    CharacterController character_controller;
    public GameObject head;
    public bool can_jump = true;
    public bool mouse_turn = true;
    public float air_speed = 4.0f;
    public float ground_speed = 6.0f;
    public float jump_speed = 8.0f;
    public float mouse_sensitivity = 100.0f;
    private Vector3 move_direction = Vector3.zero;

    private float head_rotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        character_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float temp = move_direction.y;

        if (mouse_turn) {
            move_direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        } else {
            move_direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }

        if (character_controller.isGrounded) {
            
            move_direction *= ground_speed;

            if (Input.GetButton("Jump") && can_jump) {
                move_direction.y = jump_speed;
            }

        }
        else {
            move_direction *= air_speed;
            move_direction.y = temp;
        }

        move_direction.y += Physics.gravity.y * Time.deltaTime;

        if (mouse_turn) {
            Vector3 body_rotate = new Vector3(0.0f, Input.GetAxis("Mouse X"), 0.0f) * mouse_sensitivity;
            //Vector3 head_rotate = new Vector3(-Input.GetAxis("Mouse Y"), 0.0f, 0.0f) * mouse_sensitivity;

            transform.Rotate(body_rotate * Time.deltaTime);

            //head.transform.Rotate(head_rotate * Time.deltaTime);

            head_rotation -= Input.GetAxis("Mouse Y") * mouse_sensitivity/10;
            head_rotation = Mathf.Clamp(head_rotation, -90, 90);

            head.transform.localEulerAngles = new Vector3(head_rotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        
        move_direction = transform.TransformDirection(move_direction);
        character_controller.Move(move_direction * Time.deltaTime);

    }
}
