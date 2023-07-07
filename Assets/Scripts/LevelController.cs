using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_moneyText;
    [SerializeField]
    TextMeshProUGUI m_tipStackText;
    [SerializeField]
    TextMeshProUGUI m_timeText;

    List<PlateStatus> Orders;
    int score = 0;
    int tipStack = 0;
    const int SCORE_PER_ORDER = 100;
    const int TIP = 10;
    int orderCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Orders = new();
        Orders.Capacity = 10;
        for(int i = 0; i < Orders.Capacity; i++)
        {
            Orders[i] = PlateStatus.Empty;
        }
        GenerateOrder(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateOrder(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int random = Random.Range(0, 2);
            if (random <= 1)
            {
                Orders[orderCount] = PlateStatus.withTaco_Rice_Meat;
                orderCount++;
            }
            else
            {
                Orders[orderCount] = PlateStatus.withTaco_Rice_Mushroom;
                orderCount++;
            }
            OrderDisplayLogic.Instance.AddOrderDisplay(random);
        }
    }
    public void DeliverOrder(PlateStatus order)
    {
        int orderIndex = GetOrderIndex(order);
        if (orderIndex != -1)
        {
            Orders.RemoveAt(orderIndex);
            OrderDisplayLogic.Instance.DeliverOrderDisplay(orderIndex);
            orderCount--;
            if (orderIndex == 0)
            {
                tipStack++;
            }
            else
            {
                tipStack = 0;
            }
            score += SCORE_PER_ORDER + tipStack * TIP;
            m_moneyText.text = score.ToString();
            m_tipStackText.text = tipStack.ToString();
        }
    }
    int GetOrderIndex(PlateStatus order)
    {
        for(int i = 0; i < orderCount; i++)
        {
            if (Orders[i] == order)
            {
                return i;
            }
        }
        return -1;
    }
    public int GetScore()
    {
        return score;
    }
    public int GetTipStack()
    {
        return tipStack;
    }
}
