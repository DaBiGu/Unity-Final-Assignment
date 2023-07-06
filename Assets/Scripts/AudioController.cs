using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip throwSound;
    [SerializeField]
    AudioClip cookCompleteSound;
    [SerializeField]
    AudioClip orderCompleteSound;
    [SerializeField]
    AudioClip dashSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayThrowSound()
    {
        audioSource.PlayOneShot(throwSound);
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
}
