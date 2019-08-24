using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    CharacterController character_controller;
    public bool can_jump = true;
    public float air_speed = 4.0f;
    public float ground_speed = 6.0f;
    public float jump_speed = 8.0f;

    private Vector3 move_direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        character_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float temp = move_direction.y;
        move_direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

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
        character_controller.Move(move_direction * Time.deltaTime);

    }
}
