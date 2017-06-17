using UnityEngine;
using System.Collections;
    // Adds gravity changers (1)
public class PUExtraGravityChangers : IPowerUp {

    protected override void LaunchSpecialPower(Ball ball)
    {
        ball.AddGravityChangers(1);
    }
}
