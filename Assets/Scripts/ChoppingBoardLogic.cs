using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChoppingBoardLogic : MonoBehaviour
{
    GameObject player;
    GameObject objectOnTable;
    Transform spawnPoint;
    Vector3 targetPos;
    [SerializeField]
    GameObject rawMeatPrefab;
    [SerializeField]
    GameObject rawMushroomPrefab;
    [SerializeField]
    GameObject cuttedMeatPrefab;
    [SerializeField]
    GameObject cuttedMushroomPrefab;
    // Start is called before the first frame update
    void Start()
    {
        objectOnTable = null;
        player = GameObject.FindWithTag("Player");
        spawnPoint = player.GetComponent<PlayerLogic>().GetSpawnPoint();
        targetPos = transform.position + new Vector3(0, transform.lossyScale.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool PlaceObject(GameObject target)
    {
        if (objectOnTable != null || !target.CompareTag("Food")) return false;
        if (target.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
        {
            if (target.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cutted) return false;
            objectOnTable = Instantiate(rawMeatPrefab, targetPos, transform.rotation);
        }
        else if (target.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
        {
            if (target.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cutted) return false;
            objectOnTable = Instantiate(rawMushroomPrefab, targetPos, transform.rotation);
        }
        return true;
    }
    public void CutFood()
    { 
        Vector3 targetPos = transform.position + new Vector3(0, transform.lossyScale.y, 0);
        if (objectOnTable.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
        {
            if (objectOnTable.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cutted) return;
            Destroy(objectOnTable);
            objectOnTable = Instantiate(cuttedMeatPrefab, targetPos, transform.rotation);
        }
        else if (objectOnTable.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
        {
            if (objectOnTable.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cutted) return;
            Destroy(objectOnTable);
            objectOnTable = Instantiate(cuttedMushroomPrefab, targetPos, transform.rotation);
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
}
