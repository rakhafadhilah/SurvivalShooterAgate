﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : BaseCommand
{
    PlayerShooting playerShooting;

    public ShootCommand(PlayerShooting _playerShooting)
    {
        this.playerShooting = _playerShooting;
    }

    public override void Execute()
    {
        playerShooting.Shoot();
    }

    public override void UnExecute()
    {

    }
}
