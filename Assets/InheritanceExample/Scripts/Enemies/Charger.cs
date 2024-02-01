using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    protected override void OnHit()
    {
        MoveSpeed *= 2f;   
    }
}
