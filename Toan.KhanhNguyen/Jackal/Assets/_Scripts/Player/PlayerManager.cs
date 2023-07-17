using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : JackalMono
{
    public static PlayerManager instance;
    [SerializeField] private PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;
    [SerializeField] private PlayerController playerController;
    public PlayerController PlayerController => playerController;

    protected override void Reset()
    {
        LoadComponent();
    }
    protected override void Awake()
    {
        instance = this;
    }

    public override void LoadComponent()
    {
        LoadPlayerModel();
        LoadPlayerController();
    }
    private void LoadPlayerModel()
    {
        if (playerMovement != null) return;
        playerMovement = GetComponentInChildren<PlayerMovement>();
    }
     private void LoadPlayerController()
    {
        if (playerController != null) return;
        playerController = GetComponentInChildren<PlayerController>();
    }





}
