using UnityEngine;
using System.Collections;
    // Adds points (100)
public class PUExtraPoints : IPowerUp {
	
    protected override void LaunchSpecialPower(Ball ball)
    {
        ball.AddPoints(100);
    }
}
