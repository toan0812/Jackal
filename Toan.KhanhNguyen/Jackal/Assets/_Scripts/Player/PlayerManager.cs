using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : JackalMono
{
    public static PlayerManager instance;
    [SerializeField] private PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;

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
    }
    private void LoadPlayerModel()
    {
        if (playerMovement != null) return;
        playerMovement = GetComponentInChildren<PlayerMovement>();
    }





}
