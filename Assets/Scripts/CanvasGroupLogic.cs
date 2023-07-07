using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupLogic : MonoBehaviour
{

    float m_alpha;
    [SerializeField]
    float m_alphaSpeed = 5.0f;

    CanvasGroup m_canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();
        m_alpha = m_canvasGroup.alpha;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_alpha != m_canvasGroup.alpha)
        {
            m_canvasGroup.alpha = Mathf.Lerp(m_canvasGroup.alpha, m_alpha, m_alphaSpeed * Time.deltaTime);
            Debug.Log(m_canvasGroup.alpha);
            if (Mathf.Abs(m_alpha - m_canvasGroup.alpha) <= 0.0001f)
            {
                m_canvasGroup.alpha = m_alpha;
            }
        }
    }
    public void Show()
    {
        m_alpha = 1;
        m_canvasGroup.alpha = 0;

        m_canvasGroup.blocksRaycasts = true;//可以和该UI对象交互
    }

    public void Hide()
    {
        m_alpha = 0;
        m_canvasGroup.alpha = 1;

        m_canvasGroup.blocksRaycasts = false;//不可以和该UI对象交互
    }
}
