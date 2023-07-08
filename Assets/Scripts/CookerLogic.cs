using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum CookerType
{
    Boiler,
    Pan
}
public class CookerLogic : MonoBehaviour
{
    Vector3 position;
    Quaternion rotation;
    // Vector3 scale;
    // public GameObject containingFood;
    [SerializeField]
    GameObject cookingPrefab;
    [SerializeField]
    GameObject emptyPrefab;
    [SerializeField]
    GameObject progressBar;
    [SerializeField]
    CookerType cookerType;
    [SerializeField]
    FoodType containingFood;
    [SerializeField]
    GameObject ricePrefab;
    [SerializeField]
    GameObject meatPrefab;
    [SerializeField]
    GameObject mushroomPrefab;
    [SerializeField]
    GameObject meatCookingPrefab;
    [SerializeField]
    GameObject mushroomCookingPrefab;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
        // containingFood = null;
        // scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        rotation = transform.rotation;
    }
    public void DropFood(GameObject food)
    {
        if (food.CompareTag("Food"))
        {
            if (cookerType == CookerType.Boiler && food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Rice)
            {
                Destroy(gameObject);
                GameObject target = Instantiate(cookingPrefab, position, rotation);
                target.transform.localScale = new Vector3(5, 5, 5);
                // target.GetComponent<CookerLogic>().SetContainingFood(food);
            }
            else if (cookerType == CookerType.Pan)
            {
                if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Meat &&
                        food.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cutted)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(meatCookingPrefab, position, rotation);
                    target.transform.localScale = new Vector3(5, 5, 5);
                }
                else if (food.GetComponent<FoodLogic>().GetFoodType() == FoodType.Mushroom &&
                            food.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cutted)
                {
                    Destroy(gameObject);
                    GameObject target = Instantiate(mushroomCookingPrefab, position, rotation);
                    target.transform.localScale = new Vector3(5, 5, 5);
                }
            }
        }
    }
    public GameObject TakeFood()
    {
        Destroy(gameObject);
        GameObject target = Instantiate(emptyPrefab, position, rotation);
        target.transform.localScale = new Vector3(5, 5, 5);
        if (containingFood == FoodType.Rice)
        {
            return ricePrefab;
        }
        else if (containingFood == FoodType.Meat)
        {
            return meatPrefab;
        }
        else if (containingFood == FoodType.Mushroom)
        {
            return mushroomPrefab;
        }
        return null;
    }
}
