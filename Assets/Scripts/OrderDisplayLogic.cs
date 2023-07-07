using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OrderDisplayLogic : MonoBehaviour
{
    public static OrderDisplayLogic Instance;

    [SerializeField]
    Vector2 m_spacing = new(250, 0);

    [SerializeField]
    float m_smoothTime = 0.2f;
    [SerializeField]
    List<Vector2> m_velocities = new();

    int m_count = 0;

    public GameObject[] m_orderDisplayPrefabArray;
    public List<GameObject> m_orderDisplayQueue = new();

    public GameObject AddOrderDisplay(int orderDisplayPrefabIndex)
    {
        var temp = Instantiate(m_orderDisplayPrefabArray[orderDisplayPrefabIndex], transform);
        temp.transform.localPosition = 10 * m_spacing;
        var TMP = temp.transform.Find("OrderNumber").gameObject.GetComponent<TextMeshProUGUI>();
        TMP.text = "#" + (++m_count).ToString();
        m_orderDisplayQueue.Add(temp);
        m_velocities.Add(Vector2.zero);
        return temp;
    }

    public void DeliverOrderDisplay(int orderDisplayQueueIndex) 
    {
        var temp = m_orderDisplayQueue[orderDisplayQueueIndex];
        m_orderDisplayQueue.RemoveAt(orderDisplayQueueIndex);
        m_velocities.RemoveAt(orderDisplayQueueIndex);

        var maskContainer = temp.transform.Find("CompleteMask");
        maskContainer.GetComponent<Image>().enabled = true;

        temp.GetComponent<CanvasGroupLogic>().Hide();
        Destroy(temp, 0.8f);
    }

    public void TestMeat()
    {
        AddOrderDisplay(0);
    }

    public void TestMush()
    {
        AddOrderDisplay(1);
    }
    public void DelFirst()
    {
        DeliverOrderDisplay(0);
    }
    public void DelSecond()
    {
        DeliverOrderDisplay(1);
    }

    void SmoothMove(Transform targetTransform, Vector2 targetLocalPos, int velocityListIndex)
    {
        var tempVelocity = m_velocities[velocityListIndex];
        targetTransform.localPosition = Vector2.SmoothDamp(targetTransform.localPosition, targetLocalPos, ref tempVelocity, m_smoothTime);
        m_velocities[velocityListIndex] = tempVelocity;
    }

    public GameObject GetDisplayQueueItem(int index)
    {
        return m_orderDisplayQueue[index];
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_orderDisplayQueue.Count; i++)
        {
            SmoothMove(m_orderDisplayQueue[i].transform, i * m_spacing, i);
            //Debug.Log("#" + i + ": " + m_orderDisplayQueue[i].transform + (Vector2)m_initPos + i * m_spacing);
        }
    }
}
