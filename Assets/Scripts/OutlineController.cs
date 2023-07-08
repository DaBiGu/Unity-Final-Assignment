using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    Outline[] outlineObjects;
    GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        outlineObjects = FindObjectsOfType<Outline>();
        foreach (Outline outline in outlineObjects)
        {
            outline.enabled = false;
        }
        players = GameObject.FindGameObjectsWithTag("Player");     
    }

    // Update is called once per frame
    void Update()
    {
        outlineObjects = FindObjectsOfType<Outline>();
        foreach (Outline outline in outlineObjects)
        {
            outline.enabled = false;
        }
        RaycastHit hit;
        Vector3 rayCastOffset = new Vector3(0, 0, 0);
        foreach(GameObject player in players)
        {
            Physics.Raycast(player.transform.position, player.transform.forward + rayCastOffset, out hit, 2.0f);
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Outline>() != null)
                {
                    hit.collider.GetComponent<Outline>().enabled = true;
                }
            }
        }
    }
}
