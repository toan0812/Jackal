using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : JackalMono
{
    public static GameInput instance;
    private PlayerActions playerActions;
    public event EventHandler OnShootAction;
    public event EventHandler OnShootBoomAction;

    protected override void Awake()
    {
        instance = this;
        playerActions = new PlayerActions();
        playerActions.playerAction.Enable();
        playerActions.playerAction.Shoot.performed += Shoot_performed;
        playerActions.playerAction.ShootBoom.performed += ShootBoom_performed;
    }

    private void ShootBoom_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnShootBoomAction?.Invoke(this, EventArgs.Empty);
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnShootAction?.Invoke(this, EventArgs.Empty);
    }
}
