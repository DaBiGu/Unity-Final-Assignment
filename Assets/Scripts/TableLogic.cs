using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//#TODO °¸°å 
public class TableLogic : MonoBehaviour
{
    GameObject objectOnTable;
    GameObject[] players;
    Transform spawnPoint;
    [SerializeField]
    bool spawnPlate = false;
    [SerializeField]
    GameObject platePrefab;
    // Start is called before the first frame update
    void Start()
    {
        objectOnTable = null;
        players = GameObject.FindGameObjectsWithTag("Player");
        // spawnPoint = player.GetComponent<PlayerLogic>().GetSpawnPoint();
        if (spawnPlate)
        {
            PlaceObject(platePrefab, 0);
        }
    }

    public bool PlaceObject(GameObject target, int playerID)
    {
        bool status = false;
        Vector3 targetPos = transform.position + new Vector3(0, transform.lossyScale.y, 0);
        if (objectOnTable != null && objectOnTable.CompareTag("Plate") && target.CompareTag("Food"))
        {
            if (target.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cutted ||
                    target.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cooked)
            {
                objectOnTable = objectOnTable.GetComponent<PlateLogic>().GetFood(target, playerID);
                status = true;
            }
        }
        else if (objectOnTable == null)
        {
            objectOnTable = Instantiate(target, targetPos, transform.rotation);
            status = true;
        }
        objectOnTable.transform.localScale = new Vector3(3, 3, 3);
        if (objectOnTable.CompareTag("Food") && objectOnTable.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
        {
            objectOnTable.transform.localScale = new Vector3(1, 1, 1);
        }
        if (objectOnTable.CompareTag("Food") && objectOnTable.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
        {
            objectOnTable.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
        }
        return status;
    }
    public GameObject TakeObject(int playerID)
    {
        Transform spawnPoint = null;
        foreach (GameObject player in players)
        {
            if (player.GetComponent<PlayerLogic>().GetPlayerID() == playerID)
            {
                spawnPoint = player.GetComponent<PlayerLogic>().GetSpawnPoint();
            }
        }
        GameObject target = null;
        if (objectOnTable != null)
        {
            target = Instantiate(objectOnTable, spawnPoint.position, spawnPoint.rotation);
            target.transform.SetParent(spawnPoint.transform);
            Debug.Log("Food taken.");
            Destroy(objectOnTable);
            objectOnTable = null;
        }
        return target;
    }

    public GameObject GetCooker()
    {
        if (objectOnTable.CompareTag("Cooker")) 
            return objectOnTable;
        return null;
    }
}
