using UnityEngine;
using System.Collections;
        // Makes camera follow the ball
public class CameraController : MonoBehaviour {

    public Ball ball;

    private float offsetX;

    void Start()
    {
        offsetX = transform.position.x - ball.transform.position.x;
    }

	void LateUpdate ()
    {
        transform.position = new Vector3(ball.transform.position.x + offsetX, 0, -10);
	}
}
