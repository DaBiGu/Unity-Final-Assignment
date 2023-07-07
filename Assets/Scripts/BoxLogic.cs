using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLogic : MonoBehaviour
{
    GameObject player; 
    [SerializeField]
    GameObject foodPrefab;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void OpenBox()
    {
        Transform spawnPoint = player.GetComponent<PlayerLogic>().GetSpawnPoint();
        GameObject food = Instantiate(foodPrefab, spawnPoint.position, spawnPoint.rotation);
        if (food != null)
        {
            Debug.Log("Food: Instantiated.");
        }
        else
        {
            Debug.Log("Instantiation Failed.");
        }
        food.transform.SetParent(spawnPoint);
    }
    public GameObject GetFoodType()
    {
        return foodPrefab;
    }
}
