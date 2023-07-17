using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : JackalMono
{
    private float moveSpeed = 1.2f;
    private SavedMachanicController controller;
    protected override void Awake()
    {
        base.Awake();
        LoadComponent();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, controller.transform.position, moveSpeed * Time.deltaTime);
    }


    public override void LoadComponent()
    {
        base.LoadComponent();
        LoadSaveMachine();
    }

    private void LoadSaveMachine()
    {
        if (controller != null) return;
        controller = GameObject.FindAnyObjectByType<SavedMachanicController>();
    }
}
