using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyTransition;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField]
    TransitionSettings m_transitionSetting;

    public void OnStartClicked()
    {
        Debug.Log("On Start Click");
        TransitionManager.Instance().Transition("PlayScene", m_transitionSetting, 1.0f);
    }

    public void OnQuitClicked()
    {
        Debug.Log("On Quit Click");
        Application.Quit();
    }

    public void OnChangeLanguageClicked()
    {
        LocalizationManager.Instance.ChangeLanguageFile();
    }
}
