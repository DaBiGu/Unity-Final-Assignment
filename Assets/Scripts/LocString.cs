using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class LocString : MonoBehaviour
{
    TextMeshProUGUI m_TMP;

    [InspectorLabel("Tip: Use LocalizationManager.Instance.GetLocString(\"key\") to get localized string of \"key\"")]

    // The localization key of this string. Leaving it blank will use the object's name instead.
    [SerializeField]
    string m_key;

    void Awake()
    {
        m_TMP = GetComponent<TextMeshProUGUI>();
        if (m_TMP == null)
        {
            Debug.LogError("No TextMeshProUGUI component found on " + gameObject.name);
        }

        if (m_key == "")
        {
            // Fallback to object name
            m_key = gameObject.name;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateLocText();
    }

    public void UpdateLocText()
    {
        if (m_TMP && !string.IsNullOrEmpty(m_key))
        {
            m_TMP.text = LocalizationManager.Instance.GetLocString(m_key);
            Debug.Log(m_TMP.text);
        }
        else
        {
            Debug.LogError("No TextMeshProUGUI component found on " + gameObject.name + " or key "+ m_key + " not found");
        }
    }
}
