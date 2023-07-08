using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    AudioSource audioSource;
    [SerializeField]
    AudioClip throwawaySound;
    [SerializeField]
    AudioClip cookCompleteSound;
    [SerializeField]
    AudioClip orderCompleteSound;
    [SerializeField]
    AudioClip dashSound;
    [SerializeField]
    AudioClip wrongSound;
    [SerializeField]
    AudioClip timerBeepSound;
    [SerializeField]
    AudioClip timeUpSound;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayThrowawaySound()
    {
        audioSource.PlayOneShot(throwawaySound);
    }
    public void PlayCookCompleteSound()
    {
        audioSource.PlayOneShot(cookCompleteSound);
    }
    public void PlayOrderCompleteSound()
    {
        audioSource.PlayOneShot(orderCompleteSound);
    }
    public void PlayDashSound()
    {
        audioSource.PlayOneShot(dashSound);
    }

    public void PlayWrongSound()
    {
        audioSource.PlayOneShot(wrongSound);
    }
    public void PlayTimerBeepSound()
    {
        audioSource.PlayOneShot(timerBeepSound);
    }
    public void PlayTimeUpSound()
    {
        audioSource.PlayOneShot(timeUpSound);
    }
}
