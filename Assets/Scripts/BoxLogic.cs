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
        Instantiate(foodPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public GameObject GetFoodType()
    {
        return foodPrefab;
    }
}
