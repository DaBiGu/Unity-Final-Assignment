using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class LocImageMat : MonoBehaviour
{
    Renderer m_Renderer;

    [InspectorLabel("Tip: Use LocalizationManager.Instance.GetLocString(\"key\") to get localized string of \"key\"")]

    // The localization key of this string. Leaving it blank will use the object's name instead.
    [SerializeField]
    string m_key;

    void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
        if (m_Renderer == null)
        {
            Debug.LogError("No Renderer found on " + gameObject.name);
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
        UpdateLocImageMat();
    }

    public void UpdateLocImageMat()
    {
        if (m_Renderer && !string.IsNullOrEmpty(m_key))
        {
            var temp = LocalizationManager.Instance.GetLocImageMat(m_key);
            if (temp == null)
            {
                Debug.LogError("No Material found on " + gameObject.name + " or key " + m_key + " not found");
                return;
            }
            m_Renderer.material = temp;
        }
        else
        {
            Debug.LogError("No Material component found on " + gameObject.name + " or key "+ m_key + " not found");
        }
    }
}
