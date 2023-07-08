using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameMenuLogic : MonoBehaviour
{
    [SerializeField]
    TransitionSettings m_transitionSetting;

    public void PlayAgain()
    {
        TransitionManager.Instance().Transition("PlayScene", m_transitionSetting, 0.0f);
    }

    public void QuitToMenu()
    {
        TransitionManager.Instance().Transition("MainMenu", m_transitionSetting, 0.0f);
    }
}
