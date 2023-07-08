using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoalLogic : MonoBehaviour
{
    [SerializeField]
    LevelController levelController;
    [SerializeField]
    PlateStackerLogic plateStackerLogic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool DeliverOrder(PlateStatus order)
    {
        bool status = levelController.GetComponent<LevelController>().DeliverOrder(order);
        if (status)
        {
            plateStackerLogic.StackPlate();
        }
        return status;
    }
}
