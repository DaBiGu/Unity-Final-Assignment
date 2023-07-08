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
    public void PlaceObject(GameObject target)
    {
        if (objectOnTable != null || !target.CompareTag("Food")) return;
        if (target.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
        {
            objectOnTable = Instantiate(rawMeatPrefab, targetPos, transform.rotation);
        }
        else if (target.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
        {
            objectOnTable = Instantiate(rawMushroomPrefab, targetPos, transform.rotation);
        }
    }
    public void CutFood()
    {
        if (objectOnTable.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
        {
            Destroy(objectOnTable);
            objectOnTable = Instantiate(cuttedMeatPrefab, transform.position, transform.rotation);
        }
        else if (objectOnTable.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
        {
            Destroy(objectOnTable);
            objectOnTable = Instantiate(cuttedMeatPrefab, transform.position, transform.rotation);
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
