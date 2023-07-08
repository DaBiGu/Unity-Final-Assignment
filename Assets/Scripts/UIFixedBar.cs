using CodeMonkey.HealthSystemCM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIFixedBar : MonoBehaviour
{
    //[SerializeField]
    //GameObject objFollowed;// 3D Objects to be followed
    [SerializeField]
    GameObject canvasPrefab;
    [SerializeField]
    GameObject m_barPrefab;
    public Vector2 offset = new(-1.0f, 1.0f);
    public Vector2 scale = new(0.5f, 0.5f);

    //Canvas m_canvas;

    GameObject m_displayBar;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        var tmp_canvas = GetComponentInChildren<Canvas>();
        if (tmp_canvas != null)
        {
            Destroy(tmp_canvas.gameObject);
        }
        var canvas = Instantiate(canvasPrefab, transform);
        //m_canvas = canvas.GetComponent<Canvas>();
        m_displayBar = Instantiate(m_barPrefab, canvas.transform);
        var position = screenPos + offset;
        m_displayBar.transform.position = position;
        m_displayBar.transform.localScale = scale;
        var healthSystemComp = GetComponent<HealthSystemComponent>();
        m_displayBar.GetComponent<HealthBarUI>().SetHealthSystem(healthSystemComp.GetHealthSystem());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        var position = screenPos + offset;
        m_displayBar.transform.position = position;
    }

    public void SetBarValue(float value)
    {
        var healthSystemComp = GetComponent<HealthSystemComponent>();
        healthSystemComp.GetHealthSystem().SetHealth(value);
    }
}
