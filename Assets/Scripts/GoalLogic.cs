using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//#TODO 没看过不知道对不对
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
    public void DeliverOrder(PlateStatus order)
    {
        levelController.GetComponent<LevelController>().DeliverOrder(order);
    }
}
