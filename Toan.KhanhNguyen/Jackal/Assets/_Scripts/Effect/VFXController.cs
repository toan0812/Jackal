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
    public GameObject GetBoomEffect(Transform effectTransform)
    {
        BoomEffect.SetActive(true);
        BoomEffect.transform.position = effectTransform.position;
        return BoomEffect;
    } public GameObject GetexplosionEffect(Transform effectTransform)
    {
        explosionEffect.SetActive(true);
        explosionEffect.transform.position = effectTransform.position;
        return explosionEffect;
    }




}
