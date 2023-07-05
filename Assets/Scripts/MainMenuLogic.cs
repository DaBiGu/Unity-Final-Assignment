using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public void OnStartClicked()
    {
        Debug.Log("On Start Click");
        SceneManager.LoadScene("PlayScene");
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
