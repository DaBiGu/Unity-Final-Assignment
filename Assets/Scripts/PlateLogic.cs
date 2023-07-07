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
        switch (plateStatus)
        {
            case PlateStatus.Empty:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoPrefab, transform.position, transform.rotation);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    Instantiate(withRicePrefab, transform.position, transform.rotation);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    Destroy(gameObject);
                    Instantiate(withMeatPrefab, transform.position, transform.rotation);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    Destroy(gameObject);
                    Instantiate(withMushroomPrefab, transform.position, transform.rotation);
                }
                break;
            case PlateStatus.withMeat:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    Instantiate(withRiceMeatPrefab, transform.position, transform.rotation);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoMeatPrefab, transform.position, transform.rotation);
                }
                break;
            case PlateStatus.withMushroom:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    Instantiate(withRiceMushroomPrefab, transform.position, transform.rotation);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoMushroomPrefab, transform.position, transform.rotation);
                }
                break;
            case PlateStatus.withRice:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoRicePrefab, transform.position, transform.rotation);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoMeatPrefab, transform.position, transform.rotation);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoMushroomPrefab, transform.position, transform.rotation);
                }
                break;
            case PlateStatus.withTaco:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoRicePrefab, transform.position, transform.rotation);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoMeatPrefab, transform.position, transform.rotation);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoMushroomPrefab, transform.position, transform.rotation);
                }
                break;
            case PlateStatus.withTaco_Meat:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoRiceMeatPrefab, transform.position, transform.rotation);
                }
                break;
            case PlateStatus.withTaco_Mushroom:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoRiceMushroomPrefab, transform.position, transform.rotation);
                }
                break;
            case PlateStatus.withTaco_Rice:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoRiceMeatPrefab, transform.position, transform.rotation);
                }
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoRiceMushroomPrefab, transform.position, transform.rotation);
                }
                break;
            case PlateStatus.withRice_Meat:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoRiceMeatPrefab, transform.position, transform.rotation);
                }
                break;
            case PlateStatus.withRice_Mushroom:
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Taco)
                {
                    Destroy(gameObject);
                    Instantiate(withTacoRiceMushroomPrefab, transform.position, transform.rotation);
                }
                break;
        }
    }
    public PlateStatus GetPlateStatus()
    {
        return plateStatus;
    }
}
