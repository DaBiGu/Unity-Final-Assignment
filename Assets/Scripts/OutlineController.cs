using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    Outline[] outlineObjects;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        outlineObjects = FindObjectsOfType<Outline>();
        foreach (Outline outline in outlineObjects)
        {
            outline.enabled = false;
        }
        player = GameObject.FindWithTag("Player");     
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Outline outline in outlineObjects)
        {
            outline.enabled = false;
        }
        RaycastHit hit;
        Vector3 rayCastOffset = new Vector3(0, -0.8f, 0);
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
