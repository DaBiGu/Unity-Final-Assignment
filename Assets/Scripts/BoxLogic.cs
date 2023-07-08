using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLogic : MonoBehaviour
{
    GameObject[] players; 
    [SerializeField]
    GameObject foodPrefab;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    public GameObject OpenBox(int playerID)
    {
        Transform spawnPoint = null;
        foreach (GameObject player in players)
        {
            if (player.GetComponent<PlayerLogic>().GetPlayerID() == playerID)
            {
                spawnPoint = player.GetComponent<PlayerLogic>().GetSpawnPoint();
            }
        }
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
        return food;
    }
    public GameObject GetFoodType()
    {
        return foodPrefab;
    }
}
