using UnityEngine;
using System.Collections;
        //takes care of ball behaviour and the score
public class BallMovement : MonoBehaviour {

    public float m_horizontalStartSpeed;
    public float m_horizontalMaxSpeed;
    public float m_horizontalAcceleration;
    public int m_gravityChangers;

    [HideInInspector] public bool m_bGameStarted = false;

    private int m_score;
    private float m_horizontalSpeed;
    private Rigidbody m_rigidBody;
    private bool m_bTouchedPlatform = true;

            //makes sure gravity is fine after reloding the scene and initializes variables
    void Start ()
    {               
        float gravity = -9.81f;
        Physics.gravity = new Vector3(0f, gravity);

        m_score = 0;
        m_rigidBody = gameObject.GetComponent<Rigidbody>();
        m_horizontalSpeed = m_horizontalStartSpeed;
	}
	        //controls ball's speed, rotates it and reads the input
	void Update ()
    {
        if (m_bGameStarted)
        {
            m_horizontalSpeed = m_horizontalStartSpeed + (m_score * m_horizontalAcceleration);
            if (m_horizontalSpeed >= m_horizontalMaxSpeed)
                m_horizontalSpeed = m_horizontalMaxSpeed;

            transform.Rotate(new Vector3(0f, 45f, 0f) * Time.deltaTime);

            if (Input.GetButtonDown("Gravity") && (m_bTouchedPlatform || m_gravityChangers > 0))
                ChangeGravity();
        }

    }
            //refreshes ball's position every frame
    void FixedUpdate()
    {
        if (m_bGameStarted)
        {
            Move();
        }
    }
            //changes m_bTouchedPlatform to true after ball touched any platform and adds points for touching platform
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            m_bTouchedPlatform = true;
            AddPoints(20);
        }
    }
            //adds points for distance
    void OnTriggerEnter(Collider other)
    {
        if (other. gameObject.CompareTag("Platform"))
            AddPoints(10);
    }
            //adds given amount of points
    public void AddPoints(int points)
    {
        m_score += points;
    }
            //returns score
    public int GetScore()
    {
        return m_score;
    }
            //adds gravity changers
    public void AddGravityChangers(int amount)
    {
        m_gravityChangers += amount;
    }
            //moves ball horizontaly
    private void Move()
    {
        Vector3 movement = new Vector3(m_horizontalSpeed, 0f, 0f) * Time.deltaTime;

        m_rigidBody.MovePosition(transform.position + movement);
    }
            //flips gravity
    private void ChangeGravity()
    {
        float gravity = Physics.gravity.y;
        gravity *= -1;
        Physics.gravity = new Vector3(0f, gravity, 0f);

        if (!m_bTouchedPlatform)
            m_gravityChangers--;
        else
            m_bTouchedPlatform = false;
    }            
}
