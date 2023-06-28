using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : JackalMono
{
    [Header("infor")]
    [SerializeField] protected float speed;

    protected virtual void BulletMoving(){}

    protected virtual void DestroyByDistance(Transform TargetTransform)
    {
        if(Vector2.Distance(transform.position, TargetTransform.transform.position) >= 4f)
        {
            gameObject.SetActive(false);
            VFXController.instance.GetBoomEffect(transform);
        }
    }




}
