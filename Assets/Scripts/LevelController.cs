using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    [SerializeField]
    TextMeshProUGUI m_moneyText;
    [SerializeField]
    TextMeshProUGUI m_tipStackText;
    [SerializeField]
    TextMeshProUGUI m_timeText;
    [SerializeField]
    GameObject m_UICanvas;
    [SerializeField]
    GameObject m_gameOverCanvas;
    [SerializeField]
    GameObject m_mainCamera;
    [SerializeField]
    GameObject m_timeUpSign;
    [SerializeField]
    GameObject m_goSign;

    List<PlateStatus> Orders = new();
    List<float> OrderTimers = new();
    public float levelTimer = 180.0f;
    public float orderTime = 90.0f;
    public float orderSpawnTime = 60.0f;
    float beepSpacing;
    int score = 0;
    int tipStack = 0;
    const int SCORE_PER_ORDER = 100;
    const int TIP = 10;
    const float ORDER_TIMING = 90.0f;
    const float ORDER_SPAWN_TIMING = 60.0f;
    const float BEEP_SPACING = 1.0f;
    int orderCount = 0;
    bool m_isEndgame = false;
    bool m_isStarting = true;
    float countdown = 2.0f;

    private void Awake()
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


    // Start is called before the first frame update
    void Start()
    {
        beepSpacing = BEEP_SPACING;
        //for (int i = 0; i < Orders.Capacity; i++)
        //{
        //    Orders[i] = PlateStatus.Empty;
        //}
        GenerateOrder(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isStarting)
        {
            m_goSign.SetActive(true);
            if (countdown <= 0)
            {
                m_goSign.SetActive(false);
                m_isStarting = false;
            }
            else
            {
                countdown -= Time.deltaTime;
            }
            return;
        }

        // track each order timing
        for(int i = 0; i < orderCount; i++)
        {
            OrderTimers[i] -= Time.deltaTime;
            OrderDisplayLogic.Instance.SetTimebar(i, OrderTimers[i]);
            if (OrderTimers[i] <= 0)
            {
                // order is expired
                OrderDisplayLogic.Instance.ExpiredOrderDisplay(i);
                OrderTimers[i] = ORDER_TIMING;
                //AudioController.Instance.PlayWrongSound();
                tipStack = 0;
                score -= (int)(SCORE_PER_ORDER * 0.6);
                m_moneyText.text = score.ToString();
                m_tipStackText.text = string.Format(LocalizationManager.Instance.GetLocString("TipText"), tipStack);
                // m_tipStackText.text = tipStack.ToString();
            }
        }

        // track level timer
        levelTimer -= Time.deltaTime;
        m_timeText.text = string.Format("{0:D2}:{1:D2}", (int)levelTimer / 60, (int)levelTimer % 60); 
        if (levelTimer <= 30.0f)
        {
            m_timeText.color = Color.yellow;
            beepSpacing -= Time.deltaTime;
            if (beepSpacing <= 0)
            {
                beepSpacing = BEEP_SPACING;
                //AudioController.Instance.PlayTimerBeepSound();
            }
        }
        if (levelTimer <= 0)
        {
            TimeUp();
            return;
        }

        if (orderSpawnTime <= 0)
        {
            GenerateOrder(1);
            orderSpawnTime = ORDER_SPAWN_TIMING;
        }
        else
        {
            orderSpawnTime -= Time.deltaTime;
        }
    }
    void GenerateOrder(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int random = Random.Range(0, 2);
            if (random <= 1)
            {
                Orders.Add(PlateStatus.withTaco_Rice_Meat);
                OrderTimers.Add(orderTime);
                orderCount++;
            }
            else
            {
                Orders.Add(PlateStatus.withTaco_Rice_Mushroom);
                OrderTimers.Add(orderTime);
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
            OrderTimers.RemoveAt(orderIndex);
            OrderDisplayLogic.Instance.DeliverOrderDisplay(orderIndex);
            orderCount--;
            if (orderIndex == 0)
            {
                if (tipStack < 4) tipStack++;
            }
            else
            {
                tipStack = 0;
            }
            score += SCORE_PER_ORDER + tipStack * TIP;
            m_moneyText.text = score.ToString();
            m_tipStackText.text = string.Format(LocalizationManager.Instance.GetLocString("TipText"), tipStack);
            //m_tipStackText.text = "x" + tipStack.ToString();
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

    public bool IsEndgame()
    {
        return m_isEndgame;
    }

    public void TimeUp()
    {
        m_isEndgame = true;
        //AudioController.Instance.PlayTimeUpSound();
        StartCoroutine(DisplayGameOverCanvas());
        m_timeUpSign.SetActive(true);
        var scriptList1 = FindObjectsOfType<UIFixedBar>();
        var scriptList2 = FindObjectsOfType<UIFixedIcon>();
        foreach (var item in scriptList1)
        {
            item.enabled = false;
        }
        foreach (var item in scriptList2)
        {
            item.enabled = false;
        }
        var overlayList = GameObject.FindGameObjectsWithTag("UIOverlay");
        foreach (var item in overlayList)
        {
            Destroy(item);
        }
    }

    IEnumerator DisplayGameOverCanvas()
    {
        yield return new WaitForSeconds(3f);


        m_UICanvas.GetComponent<CanvasGroupLogic>().Hide();
        m_gameOverCanvas.GetComponent<CanvasGroupLogic>().Show();
        m_mainCamera.GetComponent<PostProcessVolume>().enabled = true;
    }
}
