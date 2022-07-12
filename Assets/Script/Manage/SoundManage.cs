using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public static SoundManage instance { get; private set; }
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

   public void PlaySound(AudioClip _clip)
    {
        audioSource.PlayOneShot(_clip);
        audioSource.volume = 0.6f;
    }

    public void PauseSound()
    {
        audioSource.volume = 0f;
    }
}
