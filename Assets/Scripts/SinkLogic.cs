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
    GameObject platePrefab;
    [SerializeField]
    PlateStackerLogic plateStackerLogic;
    int plateCount;
    // Start is called before the first frame update
    void Start()
    {
        plateCount = 0;
        position = transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    public void AddPlate()
    {
        plateCount++;
        //if (plateCount > 0)
        //{
            //Destroy(gameObject);
            //Instantiate(fullSinkPrefab, position, rotation);
        //}
    }
    public void SpawnPlate()
    {
        plateCount--;
        plateStackerLogic.StackPlate();
        //if (plateCount == 0)
        //{
            //Destroy(gameObject);
            //Instantiate(emptySinkPrefab, position, rotation);
        //}
    }
}
