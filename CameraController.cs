using UnityEngine;
using System.Collections;
        //makes camera follow the ball
public class CameraController : MonoBehaviour {

    public GameObject m_player;

    private float m_offsetX;

    void Start()
    {
        m_offsetX = transform.position.x - m_player.transform.position.x;
    }

	void LateUpdate ()
    {
        transform.position = new Vector3(m_player.transform.position.x + m_offsetX, 0, -10);
	}
}
