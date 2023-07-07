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
    [SerializeField]
    Transform spawnPoint;
    Vector3 position;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        rotation = transform.rotation;

    }
    public void GetFood(GameObject food)
    {
        bool isHeld = (gameObject.transform.parent == spawnPoint);
        switch (plateStatus)
        {
            case PlateStatus.Empty:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withRicePrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withMeatPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withMushroomPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withMeat:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withRiceMeatPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoMeatPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withMushroom:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withRiceMushroomPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoMushroomPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withRice:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoRicePrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoMeatPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoMushroomPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withTaco:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoRicePrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoMeatPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoMushroomPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withTaco_Meat:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoRiceMeatPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withTaco_Mushroom:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoRiceMushroomPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withTaco_Rice:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoRiceMeatPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoRiceMushroomPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withRice_Meat:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoRiceMeatPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
            case PlateStatus.withRice_Mushroom:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(withTacoRiceMushroomPrefab, transform.position, transform.rotation);
                    if (isHeld)
                    {
                        target.transform.SetParent(spawnPoint);
                    }
                }
                break;
        }
    }
    public PlateStatus GetPlateStatus()
    {
        return plateStatus;
    }
}
