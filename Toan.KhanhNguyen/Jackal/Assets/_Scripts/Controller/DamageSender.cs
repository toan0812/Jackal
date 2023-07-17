using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : JackalMono
{
    protected int Damage;
    protected virtual int GetDamage()
    {
        return Damage;
    }

}
