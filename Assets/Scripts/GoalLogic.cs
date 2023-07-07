using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLogic : MonoBehaviour
{
    [SerializeField]
    LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DeliverOrder(PlateStatus order)
    {
        levelController.GetComponent<LevelController>().DeliverOrder(order);
    }
}
