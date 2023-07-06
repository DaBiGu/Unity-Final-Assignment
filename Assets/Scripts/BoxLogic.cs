using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLogic : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    GameObject foodPrefab;
    void OpenBox()
    {
        Instantiate(foodPrefab, spawnPoint.position, Quaternion.identity);
    }
}
