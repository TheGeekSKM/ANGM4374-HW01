using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePowerup : PowerupBase
{
    TurretController _turretController;

    void Start()
    {
        _turretController = FindObjectOfType<TurretController>();
    }

    protected override void Powerup()
    {
        _turretController.PowerUp(2f, 0.5f);
    }

    protected override void PowerDown()
    {
        // ignore
    }

    
}
