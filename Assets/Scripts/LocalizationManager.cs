using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using Unity.VisualScripting;

public enum Language
{
    en_US,
    zh_CN,
}

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    [InspectorLabel("Tip: Use LocalizationManager.Instance.GetLocString(\"key\") to get localized string of \"key\"")]

    [SerializeField]
    Language m_currentLanguage = Language.en_US;
    const Language FallbackLang = Language.en_US;

    LocString[] m_locStrings;

    readonly Dictionary<Language, TextAsset> m_localizationFiles = new();
    Dictionary<string, string> m_localizationData = new();

    void SetupLocalizationFiles()
    {
        foreach (Language language in System.Enum.GetValues(typeof(Language)))
        {
            string textAssetPath = "Localization/" + language;
            // if such text asset exists, skip
            if (m_localizationFiles.ContainsKey(language))
            {
                Debug.Log("Localization file already exists for " + language);
                continue;
            }
            TextAsset textAsset = (TextAsset)Resources.Load(textAssetPath);
            if (textAsset)
            {
                m_localizationFiles.Add(language, textAsset);
                Debug.Log("Localization file created for " + language);
            }
            else
            {
                Debug.LogError("Localization file not found for " + language);
            }
        }
    }

    void SetupLocalizationData()
    {
        TextAsset textAsset;
        if (m_localizationFiles.ContainsKey(m_currentLanguage))
        {
            Debug.Log("selected language: " + m_currentLanguage);
            textAsset = m_localizationFiles[m_currentLanguage];
        }
        else
        {
            Debug.LogError("Cannot find language data: " + m_currentLanguage);
            textAsset = m_localizationFiles[FallbackLang];
        }

        // Load corresponding XML document
        XmlDocument xmlDoc = new();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList entryList = xmlDoc.GetElementsByTagName("Entry");

        foreach (XmlNode entry in entryList)
        {
            string key = entry.FirstChild.InnerText;
            string value = entry.LastChild.InnerText;
            if (m_localizationData.ContainsKey(key))
            {
                Debug.LogError("Localization data already contains entry for key: " + key);
            }
            else
            {
                m_localizationData.Add(key, value);
                Debug.Log("Localization data added for key " + key + " with value " + value);
            }
        }
    }

    public string GetLocString(string key)
    {
        if (!m_localizationData.ContainsKey(key))
        {
            return "Key " + key + " not found";
        }
        else
        {
            return m_localizationData[key];
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        SetupLocalizationFiles();
        SetupLocalizationData();
        m_locStrings = FindObjectsOfType<LocString>();
    }

    public void ChangeLanguageFile()
    {
        m_currentLanguage = (Language)(((int)m_currentLanguage + 1) % 2);
        Debug.Log("Switch to language " + m_currentLanguage.ToString());
        m_localizationData = new Dictionary<string, string>();
        SetupLocalizationData();
        foreach (LocString locString in m_locStrings)
        {
            locString.UpdateLocText();
        }
    }
}
