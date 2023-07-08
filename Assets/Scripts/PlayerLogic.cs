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
    [SerializeField]
    GameObject emptyPlatePrefab;

    CharacterController characterController;
    Animator animator;
    GameObject objectInHand;
    Vector3 movement, rotation;
    Vector3 raycastOffset;
    RaycastHit hit;
    float horizontalInput;
    float verticalInput;
    float animatorInput;
    const float MOVEMENT_SPEED = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        objectInHand = null;
        raycastOffset = new Vector3(0f, 0f, 0f);
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
        animatorInput = Mathf.Max(Mathf.Abs(horizontalInput), Mathf.Abs(verticalInput));
        animator.SetFloat("Input", animatorInput);
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
                objectInHand = hit.collider.GetComponent<BoxLogic>().OpenBox(playerID);

                // objectInHand = hit.collider.GetComponent<BoxLogic>().GetFoodType();
            }
        }
        else if (hit.collider.CompareTag("Stove"))
        {
            GameObject cooker = hit.collider.GetComponent<StoveLogic>().GetCooker();
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand.CompareTag("Food"))
                {
                    if (objectInHand.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cutted)
                    {
                        cooker.GetComponent<CookerLogic>().DropFood(objectInHand);
                        Destroy(objectInHand);
                    }
                }
                else if (objectInHand.CompareTag("Plate"))
                {
                    objectInHand = objectInHand.GetComponent<PlateLogic>().GetFood(
                        cooker.GetComponent<CookerLogic>().TakeFood(), playerID);
                }
            }
        }
        else if (hit.collider.CompareTag("Goal"))
        {
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand.CompareTag("Plate"))
                {
                    bool status = hit.collider.GetComponent<GoalLogic>().DeliverOrder(
                                    objectInHand.GetComponent<PlateLogic>().GetPlateStatus());
                    if (status)
                    {
                        Destroy(objectInHand);
                        objectInHand = null;
                    }
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
            else if (Input.GetButtonDown("Use_" + playerID))
            {
                hit.collider.GetComponent<SinkLogic>().SpawnPlate();
            }
        }
        else if (hit.collider.CompareTag("Table"))
        {
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand == null)
                {
                    GameObject target = hit.collider.GetComponent<TableLogic>().TakeObject(playerID);
                    objectInHand = target;
                    // Instantiate(target, spawnPoint.position, spawnPoint.rotation);
                }
                else if (objectInHand.CompareTag("Plate") || objectInHand.CompareTag("Food"))
                {
                    bool result = hit.collider.GetComponent<TableLogic>().PlaceObject(objectInHand, playerID);
                    if (result)
                    {
                        Destroy(objectInHand);
                        objectInHand = null;
                    }
                }
            }
        }
        else if (hit.collider.CompareTag("Trash Bin"))
        {
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand.CompareTag("Plate"))
                {
                    Vector3 tempPosition = objectInHand.transform.position;
                    Quaternion tempRotation = objectInHand.transform.rotation;
                    Destroy(objectInHand);
                    GameObject target = Instantiate(emptyPlatePrefab, tempPosition, tempRotation);
                    objectInHand = target;
                    target.transform.SetParent(spawnPoint);
                }
                else if (objectInHand.CompareTag("Food"))
                {
                    Destroy(objectInHand);
                    objectInHand = null;
                }
            }
        }
        else if (hit.collider.CompareTag("Chopping Board"))
        {
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand == null)
                {
                    objectInHand = hit.collider.GetComponent<ChoppingBoardLogic>().TakeObject(playerID);
                }
                else if (objectInHand.CompareTag("Food"))
                {
                    bool result = hit.collider.GetComponent<ChoppingBoardLogic>().PlaceObject(objectInHand);
                    if (result)
                    {
                        Destroy(objectInHand);
                        objectInHand = null;
                    }
                }             
            }
            else if (Input.GetButtonDown("Use_" + playerID))
            {
                hit.collider.GetComponent<ChoppingBoardLogic>().CutFood();
            }
        }
        else if (hit.collider.CompareTag("Plate Stacker"))
        {
            if (Input.GetButtonDown("Pick_" + playerID))
            {
                if (objectInHand == null)
                {
                    objectInHand = hit.collider.GetComponent<PlateStackerLogic>().RemovePlate(playerID);
                }
            }
        }
    }
    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }
    public int GetPlayerID()
    {
        return playerID;
    }   
}
