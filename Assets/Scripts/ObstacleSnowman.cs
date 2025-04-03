using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSnowman : Obstacle
{
    protected override void PlayerCollision()
    {
        base.PlayerCollision();
        Destroy(gameObject);
    }
}
