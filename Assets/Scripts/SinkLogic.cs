using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkLogic : MonoBehaviour
{
    Vector3 position;
    Quaternion rotation;
    [SerializeField]
    GameObject emptySinkPrefab;
    [SerializeField]
    GameObject fullSinkPrefab;
    [SerializeField]
    Transform plateSpawnPoint;
    int plateCount;
    // Start is called before the first frame update
    void Start()
    {
        plateCount = 0;
        position = transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPlate()
    {
        plateCount++;
        if (plateCount > 0)
        {
            Destroy(gameObject);
            Instantiate(fullSinkPrefab, position, rotation);
        }
    }
    public void WashPlate()
    {
        plateCount--;
        Instantiate(plateSpawnPoint, plateSpawnPoint.position, plateSpawnPoint.rotation);
        if (plateCount == 0)
        {
            Destroy(gameObject);
            Instantiate(emptySinkPrefab, position, rotation);
        }
    }
}
