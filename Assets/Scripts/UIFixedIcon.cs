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
    GameObject canvasPrefab;
    public Vector2 offset = new(-1.0f, 1.0f);
    public Vector2 spacing = new(5f, 0f);

    public List<GameObject> m_iconPrefab;

    GameObject canvas;

    public List<GameObject> m_displayIcons;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        var tmp_canvas = GetComponentInChildren<Canvas>();
        m_displayIcons = new();
        if (tmp_canvas != null)
        {
            Destroy(tmp_canvas.gameObject);
        }
        canvas = Instantiate(canvasPrefab, transform);
        //m_canvas = canvas.GetComponent<Canvas>();
        for (int i = 0; i < m_iconPrefab.Count; i++)
        {
            float specSpacingCount = i - (m_iconPrefab.Count - 1) / 2;
            var position = screenPos + offset + spacing * specSpacingCount;
            var icon = Instantiate(m_iconPrefab[i], canvas.transform);
            icon.transform.position = position;
            m_displayIcons.Add(icon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        for (int i = 0; i < m_displayIcons.Count; i++)
        {
            float specSpacingCount = i - (m_displayIcons.Count - 1) / 2;
            var position = screenPos + offset + spacing * specSpacingCount;
            m_displayIcons[i].transform.position = position;
        }
    }

    public void AddIcon(GameObject iconPrefab)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        m_iconPrefab.Add(iconPrefab);
        var icon = Instantiate(iconPrefab, canvas.transform);
        icon.transform.position = screenPos + offset + spacing * (m_displayIcons.Count + 1);
        m_displayIcons.Add(icon);
    }
}
