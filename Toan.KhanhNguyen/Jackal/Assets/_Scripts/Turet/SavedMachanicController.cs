using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedMachanicController : MonoBehaviour
{
    [SerializeField] private float helicopSpeed;
    [SerializeField] private Transform stationTransform;
    [SerializeField] private Transform destinTransform;
    [SerializeField] private int savedSoldier;
    private bool canMove = true;
    void Update()
    {
        Movingplatform();
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, destinTransform.position, helicopSpeed * Time.deltaTime);
        }
            
    }
    private void Movingplatform()
    {
        if (Vector2.Distance(transform.position, stationTransform.position) <= 0.5f)
        {
            canMove = false;
            if(savedSoldier <= 0)
            {
                canMove = true;
            }
        }
        if (Vector2.Distance(transform.position, destinTransform.position) <= 0.2f) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ally"))
        {
            UIManager.Instance.UpdateScore(500);
            collision.gameObject.SetActive(false);
            savedSoldier--;
        }
    }

}
