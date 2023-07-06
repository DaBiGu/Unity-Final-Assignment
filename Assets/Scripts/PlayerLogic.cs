using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    Vector3 movement;
    float horizontalInput;
    float verticalInput;
    const float MOVEMENT_SPEED = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        movement.x = horizontalInput * MOVEMENT_SPEED * Time.deltaTime;
        movement.z = verticalInput * MOVEMENT_SPEED * Time.deltaTime;
        characterController.Move(movement);
    }
}
