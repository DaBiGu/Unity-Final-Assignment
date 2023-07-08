using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType
{
    None,
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
