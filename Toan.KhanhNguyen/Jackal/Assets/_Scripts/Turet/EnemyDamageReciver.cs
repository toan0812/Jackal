using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReciver : DamageReciver
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform parentTransform;
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if(currentHealth <=0)
        {
            VFXController.instance.GetBoomEffect(transform);
            parentTransform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision == Physics2D.OverlapCircle(transform.position, 0.8f, layerMask))
        {
            currentHealth -= 1;
            //
        }
    }

}
