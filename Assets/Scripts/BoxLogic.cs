using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLogic : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    GameObject foodPrefab;
    public void OpenBox()
    {
        Instantiate(foodPrefab, spawnPoint.position, Quaternion.identity);
    }
    public GameObject GetFoodType()
    {
        return foodPrefab;
    }
}
