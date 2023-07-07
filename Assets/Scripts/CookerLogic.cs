using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookerLogic : MonoBehaviour
{
    Vector3 position;
    Quaternion rotation;
    GameObject containingFood;
    [SerializeField]
    GameObject cookingPrefab;
    [SerializeField]
    GameObject emptyPrefab;
    [SerializeField]
    GameObject progressBar;
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
    public void DropFood(GameObject food)
    {
        if (food.CompareTag("Food"))
        {
            if (food.GetComponent<FoodLogic>().GetFoodStatus() == FoodStatus.Cutted)
            {
                containingFood = food;
                Destroy(gameObject);
                Instantiate(cookingPrefab, position, rotation);
                progressBar.GetComponent<ProgressBarLogic>().StartProgress();
            }
        }
    }
    public GameObject TakeFood()
    {
        Destroy(gameObject);
        Instantiate(emptyPrefab, position, rotation);
        containingFood.GetComponent<FoodLogic>().SetFoodStatus(FoodStatus.Cooked);
        return containingFood;
    }
}
