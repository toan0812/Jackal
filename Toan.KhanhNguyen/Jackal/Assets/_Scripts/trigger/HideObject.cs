using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    [SerializeField] private float TimeWating;
    [SerializeField] private float TimeWatingMax;
    private PrisonController prisonController;
    private void Start()
    {
        prisonController = GetComponentInParent<PrisonController>();    
        TimeWating = TimeWatingMax;
    }
    void Update()
    {
        if(prisonController.canSpawn)
        {
            TimeWating -= Time.deltaTime;
        }       
        if(TimeWating <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
