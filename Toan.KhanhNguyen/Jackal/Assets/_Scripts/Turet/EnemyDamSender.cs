using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamSender : DamageSender
{
    [SerializeField] private int enemyDamage;
    protected override int GetDamage()
    {
        return enemyDamage;
    }
}
