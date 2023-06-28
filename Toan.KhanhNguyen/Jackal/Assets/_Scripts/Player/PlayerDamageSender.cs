using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSender : DamageSender
{
    [SerializeField] private int playerDamage;
    protected override int GetDamage()
    {
        return playerDamage;
    }
}
