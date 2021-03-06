﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public int actualMode;
    //0 - nothing, 1 - hold, 2 - holding;
    private GameObject player;
    private PlayerController playerController;
    private void Awake()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    public void InteractionButton()
    {
        if (actualMode == 1 && !playerController.isholding)
        {
            playerController.GrabItem();
        }

        else if (playerController.isholding) 
        {
            playerController.DropItem();
        }

    }
}
