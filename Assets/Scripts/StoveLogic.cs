using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveLogic : MonoBehaviour
{
    GameObject objectOnTable;
    GameObject player;
    Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        objectOnTable = null;
        player = GameObject.FindWithTag("Player");
        spawnPoint = player.GetComponent<PlayerLogic>().GetSpawnPoint();
    }

    public void PlaceObject(GameObject cooker)
    {
        if (cooker.CompareTag("Cooker"))
        {
            objectOnTable = cooker;
            Vector3 targetPos = transform.position + new Vector3(0, 0.5f, 0);
            Instantiate(cooker, targetPos, transform.rotation);
        }
    }
    public GameObject TakeObject()
    {
        GameObject cooker = objectOnTable;
        if (objectOnTable != null)
        {
            Instantiate(objectOnTable, spawnPoint.position, spawnPoint.rotation);
        }
        Destroy(objectOnTable);
        objectOnTable = null;
        return cooker;
    }

    public GameObject GetCooker()
    {
        return objectOnTable;
    }
    void Update()
    {
        objectOnTable = null;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.up, out hit, 2.0f);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Cooker"))
            {
                objectOnTable = hit.collider.gameObject;
            }
        }
    }
}
