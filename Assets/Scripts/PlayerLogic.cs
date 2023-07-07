using CodeMonkey.HealthSystemCM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    int playerID;

    CharacterController characterController;
    Animator animator;
    GameObject objectInHand;
    Vector3 movement, rotation;
    Vector3 raycastOffset;
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
        raycastOffset = new Vector3(0f, -1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal_" + playerID);
        verticalInput = Input.GetAxis("Vertical_" + playerID);
        PickUp();
    }
    void FixedUpdate()
    {

        movement.x = horizontalInput * MOVEMENT_SPEED * Time.deltaTime;
        movement.z = verticalInput * MOVEMENT_SPEED * Time.deltaTime;
        characterController.Move(movement);
        rotation.x = Input.GetAxisRaw("Horizontal_" + playerID);
        rotation.z = Input.GetAxisRaw("Vertical_" + playerID);
        if (rotation != Vector3.zero) 
        {
            transform.LookAt(transform.position + rotation);
        }
    }

    void PickUp()
    {
        float pickUpRange = 3f;
        bool isHit = Physics.Raycast(transform.position + raycastOffset, transform.forward, out hit, pickUpRange);
        if (!isHit)
        {
            return;
        }
        if (hit.collider.CompareTag("Food Box"))
        {
            if (Input.GetButtonDown("Pick_" + playerID) && objectInHand == null)
            {
                Debug.Log("Tried to Pick from: " + hit.collider.name);
                hit.collider.GetComponent<BoxLogic>().OpenBox();

                objectInHand = hit.collider.GetComponent<BoxLogic>().GetFoodType();
            }
        }
        else if (hit.collider.CompareTag("Cooker"))
        {
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand.CompareTag("Food"))
                {
                    hit.collider.GetComponent<CookerLogic>().DropFood(objectInHand);
                    Destroy(objectInHand);
                }
                else if (objectInHand.CompareTag("Plate"))
                {
                    objectInHand.GetComponent<PlateLogic>().GetFood(
                        hit.collider.GetComponent<CookerLogic>().TakeFood());
                }
            }
        }
        else if (hit.collider.CompareTag("Goal"))
        {
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand.CompareTag("Plate"))
                {
                    hit.collider.GetComponent<GoalLogic>().DeliverOrder(
                        objectInHand.GetComponent<PlateLogic>().GetPlateStatus());
                }
            }
        }
        else if (hit.collider.CompareTag("Sink"))
        {
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand.CompareTag("Plate"))
                {
                    if (objectInHand.GetComponent<PlateLogic>().GetPlateStatus() == PlateStatus.Dirty)
                    {
                        hit.collider.GetComponent<SinkLogic>().AddPlate();
                        Destroy(objectInHand);
                    }
                }
            }
            else if (Input.GetButtonDown("Action"))
            {
                hit.collider.GetComponent<SinkLogic>().WashPlate();
            }
        }
        else if (hit.collider.CompareTag("Table"))
        {
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand.CompareTag("Plate"))
                {
                    hit.collider.GetComponent<TableLogic>().PlaceObject(objectInHand);
                    Destroy(objectInHand);
                }
                else if (objectInHand == null)
                {
                    GameObject target = hit.collider.GetComponent<TableLogic>().TakeObject();
                    objectInHand = target;
                }
            }
        }
    }
    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }
}
