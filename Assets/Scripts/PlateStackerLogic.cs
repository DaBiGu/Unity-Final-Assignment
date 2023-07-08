using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateStackerLogic : MonoBehaviour
{
    [SerializeField]
    GameObject platePrefab;
    int plateCount;
    GameObject[] plates;
    GameObject[] players;
    Vector3 offset;
    Vector3 baseOffset;
    // Start is called before the first frame update
    void Start()
    {
        plateCount = 0;
        offset = new Vector3(0, 0.2f, 0);
        baseOffset = new Vector3(0, transform.lossyScale.y, 0);
        plates = new GameObject[10];
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StackPlate()
    {
        GameObject newPlate = Instantiate(platePrefab, transform.position + baseOffset 
                                    + offset * plateCount, transform.rotation);
        plateCount++;
        plates[plateCount] = newPlate;
    }
    public GameObject RemovePlate(int playerID)
    {
        Transform spawnPoint = null;
        foreach(GameObject player in players)
        {
            if (player.GetComponent<PlayerLogic>().GetPlayerID() == playerID)
            {
                spawnPoint = player.GetComponent<PlayerLogic>().GetSpawnPoint();
            }
        }
        GameObject target = Instantiate(platePrefab, spawnPoint.position, spawnPoint.rotation);
        target.transform.SetParent(spawnPoint);
        Destroy(plates[plateCount]);
        plateCount--;
        return target;
    }
}
