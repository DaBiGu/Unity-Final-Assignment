using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType
{
    Rice,
    Meat,
    Mushroom,
    Taco
}
public enum FoodStatus
{
    Raw,
    Cutted,
    Cooked
}
public class FoodLogic : MonoBehaviour
{
    [SerializeField]
    FoodType foodType;
    [SerializeField]
    FoodStatus foodStatus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFoodStatus(FoodStatus status)
    {
        foodStatus = status;
    }
    public FoodStatus GetFoodStatus() 
    {         
        return foodStatus;
    }
    public FoodType GetFoodType()
    {
        return foodType;
    }
}
