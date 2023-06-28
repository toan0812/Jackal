using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private LayerMask BomLayer;
    [SerializeField] private Vector2 Size;
    [SerializeField] private Transform childTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Physics2D.OverlapBox(transform.position, Size, BomLayer))
        {
            VFXController.instance.GetexplosionEffect(transform);
            childTransform.gameObject.SetActive(false);
            Size = Vector2.zero;
        }
    }
}
