using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIFixedIcon : MonoBehaviour
{
    //[SerializeField]
    //GameObject objFollowed;// 3D Objects to be followed
    [SerializeField]
    RectTransform rectTrans;// UI elements following the object
    public Vector2 offset = new(-1, 1);
    public Vector2 spacing = new(0.5f, 0f);

    public List<GameObject> m_iconPrefab;

    Canvas m_canvas;

    public List<GameObject> m_displayIcons;

    // Start is called before the first fr1ame update
    void Start()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        m_canvas = FindObjectOfType<Canvas>();
        for (int i = 0; i < m_iconPrefab.Count; i++)
        {
            var position = screenPos + offset + spacing * i;
            var icon = Instantiate(m_iconPrefab[i], m_canvas.transform);
            icon.transform.position = position;
            m_displayIcons.Add(icon);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        for (int i = 0; i < m_iconPrefab.Count; i++)
        {
            var position = screenPos + offset + spacing * i;
            m_displayIcons[i].transform.position = position;
        }
    }

    void OnDestroy()
    {
        foreach (var icon in m_displayIcons)
        {
            Destroy(icon.gameObject);
        }
    }

    public void AddIcon(GameObject iconPrefab)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        m_iconPrefab.Add(iconPrefab);
        var icon = Instantiate(iconPrefab, m_canvas.transform);
        icon.transform.position = screenPos + offset + spacing * (m_displayIcons.Count + 1);
        m_displayIcons.Add(icon);
    }
}
