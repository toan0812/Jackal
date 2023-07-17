using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TriggerHeli : MonoBehaviour
{
    [SerializeField] GameObject Helicopter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Helicopter.SetActive(true);
        }
    }
}
