using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : JackalMono
{ 
   public static VFXController instance;
   [SerializeField]private GameObject BoomEffect;
   [SerializeField]private GameObject explosionEffect;

    protected override void Awake()
    {
        instance = this;
    }
    public GameObject GetBoomEffect(Transform effectTransform, AudioClip audioClip)
    {
        BoomEffect.SetActive(true);
        BoomEffect.transform.position = effectTransform.position;
        SoundManager.instance.PlaySound(audioClip);
        return BoomEffect;
    } 
    public GameObject GetBulletEffect(Transform effectTransform, AudioClip audioClip)
    {
        BoomEffect.SetActive(true);
        BoomEffect.transform.position = effectTransform.position;
        SoundManager.instance.PlaySound(audioClip);
        return BoomEffect;
    } 
    public GameObject GetexplosionEffect(Transform effectTransform, AudioClip audioClip)
    {
        explosionEffect.SetActive(true);
        explosionEffect.transform.position = effectTransform.position;
        SoundManager.instance.PlaySound(audioClip);
        return explosionEffect;
    }




}
