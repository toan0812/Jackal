using System;
using System.Collections.Generic;
using UnityEngine;

public class Station : JackalMono
{
    public event EventHandler OnSpawn;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OnSpawn?.Invoke(this, EventArgs.Empty);
        }
    }
}
