using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//#TODO û������֪���Բ���
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
