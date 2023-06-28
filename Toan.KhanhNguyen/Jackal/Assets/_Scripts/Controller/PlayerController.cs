using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : JackalMono
{
    private int amountAllySaved;
    public int AmountAllySaved => amountAllySaved;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ally"))
        {
            amountAllySaved++;
        }
    }
}
