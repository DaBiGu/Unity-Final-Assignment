using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    GameObject objectInHand;
    Vector3 movement;
    RaycastHit hit;
    float horizontalInput;
    float verticalInput;
    const float MOVEMENT_SPEED = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        objectInHand = null;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Physics.Raycast(transform.position, transform.forward, out hit);
        if (hit.collider.tag == "Food Box")
        {
            if (Input.GetButtonDown("Pick") && objectInHand == null)
            {
                hit.collider.GetComponent<BoxLogic>().OpenBox();
                objectInHand = hit.collider.GetComponent<BoxLogic>().GetFoodType();
            }
        }
        else if (hit.collider.tag == "Cooker")
        {
            if (Input.GetButtonDown("Pick"))
            {
                if (objectInHand.tag == "Food")
                {
                    hit.collider.GetComponent<CookerLogic>().DropFood(objectInHand);
                    Destroy(objectInHand);
                }
                else if (objectInHand.tag == "Plate")
                {
                    objectInHand.GetComponent<PlateLogic>().GetFood(
                        hit.collider.GetComponent<CookerLogic>().TakeFood());
                }
            }
        }
    }
    void FixedUpdate()
    {
        movement.x = horizontalInput * MOVEMENT_SPEED * Time.deltaTime;
        movement.z = verticalInput * MOVEMENT_SPEED * Time.deltaTime;
        characterController.Move(movement);
    }
}
