using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    CharacterController character_controller;

    public GameObject body;
    private Animator animation;
    public float _moveSpeed = 6.0f;
    public float _rotateSpeed = 2.0f;
    private Vector3 _moveDirection = Vector3.zero;

    void Start() {
        character_controller = GetComponent<CharacterController>();
        animation = body.GetComponent<Animator>();
    }

    void Update() {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        animation.SetBool("Waling", _moveDirection.magnitude > 0.0f);

        _moveDirection *= _moveSpeed;

        _moveDirection += Physics.gravity;
        character_controller.Move(_moveDirection * Time.deltaTime);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            Vector3 point = hit.point;
            point.y = transform.position.y;
            Vector3 targetDir = point - transform.position;

            float step = _rotateSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(body.transform.forward, targetDir, step, 0.0f);

            body.transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
