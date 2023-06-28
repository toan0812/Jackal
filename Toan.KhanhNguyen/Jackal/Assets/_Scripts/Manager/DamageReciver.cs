using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageReciver : JackalMono
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }


}
