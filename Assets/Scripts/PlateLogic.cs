using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//#TODO 告诉锅你的盘子更新了
public enum PlateStatus
{
    Dirty,
    Empty,
    withTaco,
    withRice,
    withMeat,
    withMushroom,
    withRice_Meat,
    withRice_Mushroom,
    withTaco_Rice,
    withTaco_Meat,
    withTaco_Mushroom,
    withTaco_Rice_Meat,
    withTaco_Rice_Mushroom

}
public class PlateLogic : MonoBehaviour
{
    [SerializeField]
    PlateStatus plateStatus;
    [SerializeField]
    GameObject cleanPlatePrefab;
    [SerializeField]
    GameObject withTacoPrefab;
    [SerializeField]
    GameObject withRicePrefab;
    [SerializeField]
    GameObject withMeatPrefab;
    [SerializeField]
    GameObject withMushroomPrefab;
    [SerializeField]
    GameObject withTacoRicePrefab;
    [SerializeField]
    GameObject withTacoMeatPrefab;
    [SerializeField]
    GameObject withTacoMushroomPrefab;
    [SerializeField]
    GameObject withRiceMeatPrefab;
    [SerializeField]
    GameObject withRiceMushroomPrefab;
    [SerializeField]
    GameObject withTacoRiceMeatPrefab;
    [SerializeField]
    GameObject withTacoRiceMushroomPrefab;
    // [SerializeField]
    Transform spawnPoint;
    GameObject player;
    Vector3 position;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
        player = GameObject.FindWithTag("Player");
        spawnPoint = player.GetComponent<PlayerLogic>().GetSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        rotation = transform.rotation;

    }
    public GameObject GetFood(GameObject food)
    {
        bool isHeld = (gameObject.transform.parent == spawnPoint);
        if (food.GetComponent<FoodLogic>().GetFoodStatus() != FoodStatus.Cooked) return null;
        GameObject target = null;
        switch (plateStatus)
        {
            case PlateStatus.Empty:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    target = Instantiate(withTacoPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    target = Instantiate(withRicePrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    target = Instantiate(withMeatPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    target = Instantiate(withMushroomPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withMeat:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    target = Instantiate(withRiceMeatPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                { 
                    target = Instantiate(withTacoMeatPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withMushroom:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    target = Instantiate(withRiceMushroomPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    target = Instantiate(withTacoMushroomPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withRice:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    target = Instantiate(withTacoRicePrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    target = Instantiate(withTacoMeatPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    target = Instantiate(withTacoMushroomPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withTaco:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    target = Instantiate(withTacoRicePrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    target = Instantiate(withTacoMeatPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    target = Instantiate(withTacoMushroomPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withTaco_Meat:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    target = Instantiate(withTacoRiceMeatPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withTaco_Mushroom:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    target = Instantiate(withTacoRiceMushroomPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withTaco_Rice:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    target = Instantiate(withTacoRiceMeatPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    target = Instantiate(withTacoRiceMushroomPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withRice_Meat:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    target = Instantiate(withTacoRiceMeatPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withRice_Mushroom:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    target = Instantiate(withTacoRiceMushroomPrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
        }
        return target;
    }
    public PlateStatus GetPlateStatus()
    {
        return plateStatus;
    }
}
