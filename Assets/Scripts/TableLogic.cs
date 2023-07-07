using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//#TODO °¸°å 
public class TableLogic : MonoBehaviour
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

    public void PlaceObject(GameObject target)
    {
        Vector3 targetPos = transform.position + new Vector3(0, 2.5f, 0);
        objectOnTable = Instantiate(target, targetPos, transform.rotation);
    }
    public GameObject TakeObject()
    {
        GameObject target = null;
        if (objectOnTable != null)
        {
            target = Instantiate(objectOnTable, spawnPoint.position, spawnPoint.rotation);
            target.transform.SetParent(spawnPoint.transform);
            Debug.Log("Food taken.");
            Destroy(objectOnTable);
            objectOnTable = null;
        }
        return target;
    }

    public GameObject GetCooker()
    {
        if (objectOnTable.CompareTag("Cooker")) 
            return objectOnTable;
        return null;
    }
}
