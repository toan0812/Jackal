using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //[SerializeField] private LayerMask BomLayer;
    //[SerializeField] private Vector2 Size;
    [SerializeField] private Transform childTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBulletBom"))
        {
            VFXController.instance.GetexplosionEffect(transform,SoundManager.instance.buildExplosionSound);
            UIManager.Instance.UpdateScore(500);
            childTransform.gameObject.SetActive(false);
        }
    }
}
