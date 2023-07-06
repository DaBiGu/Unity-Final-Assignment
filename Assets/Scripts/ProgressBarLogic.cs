using CodeMonkey.HealthSystemCM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ProgressBarType
{
    chop,
    cook,
    timer
}
public class ProgressBarLogic : MonoBehaviour
{
    HealthSystem healthSystem;
    [SerializeField]
    ProgressBarType type;
    [SerializeField]
    float timerCountDown;
    [SerializeField]
    Image progressBarImage;
    const float CHOP_TIME = 2.0f;
    const float CHOP_UPDATE_TIME = 0.4f;
    const float COOK_TIME = 5.0f;
    const float MAX_HEALTH = 100;
    float timeCount;
    bool progressComplete;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem(MAX_HEALTH);
        if (type == ProgressBarType.timer)
        {
            healthSystem.SetHealth(MAX_HEALTH);
            timeCount = timerCountDown;
        }
        else
        {
            healthSystem.SetHealth(0);
            timeCount = 0.0f;
        }
        progressBarImage.color = new Color(0, 255, 0);
        progressComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == ProgressBarType.cook)
        {
            timeCount += Time.deltaTime;
            healthSystem.SetHealth(timeCount / COOK_TIME * MAX_HEALTH);
            if (timeCount >= COOK_TIME)
            {
                timeCount = 0.0f;
            }
        }
        else if (type == ProgressBarType.chop)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= CHOP_UPDATE_TIME)
            {
                timeCount = 0.0f;
                healthSystem.Heal(CHOP_UPDATE_TIME / CHOP_TIME * MAX_HEALTH);
            }
        }
        else if (type == ProgressBarType.timer)
        {
            timeCount -= Time.deltaTime;
            healthSystem.SetHealth(timeCount / timerCountDown * MAX_HEALTH);
            if (healthSystem.GetHealth() <= 66.66f)
            {
                progressBarImage.color = new Color(255, 255, 0);
            }
            if (healthSystem.GetHealth() <= 33.33f)
            {
                progressBarImage.color = new Color(255, 0, 0);
            }
        }
        if (healthSystem.GetHealth() >= MAX_HEALTH)
        {
            progressComplete = true;
        }   
    }
    // After complete, other scripts handle their logic (e.g. play audio, change prefab etc.)
    public bool GetProgressComplete()
    {
        return progressComplete;
    }   
}
