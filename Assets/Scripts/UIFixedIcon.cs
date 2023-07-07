using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIFixedIcon : MonoBehaviour
{
    //[SerializeField]
    //GameObject objFollowed;// 3D Objects to be followed
    [SerializeField]
    RectTransform rectTrans;// UI elements following the object
    public Vector2 offset = new(-1, 1);
    public Vector2 spacing = new(0.5f, 0f);
    [SerializeField]
    RectTransform[] m_IconPrefab;

    Canvas m_canvas;

    RectTransform[] m_thisIcons;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        m_canvas = FindObjectOfType<Canvas>();
        for (int i = 0; i < m_IconPrefab.Length; i++)
        {
            var position = screenPos + offset + spacing * i;
            m_thisIcons[i] = Instantiate(m_IconPrefab[i]);
            m_thisIcons[i].position = position;
            m_thisIcons[i].SetParent(m_canvas.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        for (int i = 0; i < m_IconPrefab.Length; i++)
        {
            var position = screenPos + offset + spacing * i;
            m_thisIcons[i].position = position;
        }
    }

    void OnDestroy()
    {
        foreach (var icon in m_thisIcons)
        {
            Destroy(icon.gameObject);
        }
    }
}
