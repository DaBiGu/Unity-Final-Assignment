using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//#TODO ���� 
public class TableLogic : MonoBehaviour
{
    GameObject objectOnTable;
    GameObject player;
    Transform spawnPoint;
    [SerializeField]
    bool spawnPlate = false;
    [SerializeField]
    GameObject platePrefab;
    // Start is called before the first frame update
    void Start()
    {
        objectOnTable = null;
        player = GameObject.FindWithTag("Player");
        spawnPoint = player.GetComponent<PlayerLogic>().GetSpawnPoint();
        if (spawnPlate)
        {
            PlaceObject(platePrefab);
        }
    }

    public void PlaceObject(GameObject target)
    {
        Debug.Log(target.name);
        Vector3 targetPos = transform.position + new Vector3(0, transform.lossyScale.y, 0);
        if (objectOnTable != null && objectOnTable.CompareTag("Plate") && target.CompareTag("Food"))
        {
            objectOnTable = objectOnTable.GetComponent<PlateLogic>().GetFood(target);
        }
        else
        {
            objectOnTable = Instantiate(target, targetPos, transform.rotation);
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
    }
    public GameObject TakeObject()
    {
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
