using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateStackerLogic : MonoBehaviour
{
    [SerializeField]
    GameObject platePrefab;
    int plateCount;
    GameObject[] plates;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        plateCount = 0;
        offset = new Vector3(0, 1, 0);
        plates = new GameObject[10];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StackPlate()
    {
        plateCount++;
        GameObject newPlate = Instantiate(platePrefab, transform.position + offset * plateCount, transform.rotation);
        plates[plateCount] = newPlate;
    }
    public GameObject RemovePlate()
    {
        GameObject target = plates[plateCount];
        Destroy(plates[plateCount]);
        plateCount--;
        return target;
    }
}
