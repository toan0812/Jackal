using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip boomSound;
    public AudioClip bulletSound;
    public AudioClip playerExplosionSound;
    public AudioClip turretExplosionSound;
    public AudioClip soldierSound;
    public AudioClip pickUpSound;
    public AudioClip buildExplosionSound;

    public static SoundManager instance;
    [SerializeField] private AudioSource introSound;
    [SerializeField] private AudioSource VfxSound;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        introSound.Play();
    }

    public void PlaySound(AudioClip audioClip)
    {
        VfxSound.PlayOneShot(audioClip);
    }
}
