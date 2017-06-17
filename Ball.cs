using UnityEngine;
using System.Collections;
    // Takes care of ball behaviour and the score
public class Ball : MonoBehaviour {

    private const float horizontalStartSpeed = 5.0f;
    private const float horizontalMaxSpeed = 15.0f;
    private const  float horizontalAcceleration = 0.02f;

    private float horizontalSpeed;

    private int gravityChangers = 1;
    private int score;

    private bool bTouchedPlatform = true;

    private Rigidbody rigidBody;

        // Initializes variables
    void Start ()
    {               
        float gravity = -9.81f;
        Physics.gravity = new Vector3(0f, gravity);

        score = 0;
        horizontalSpeed = horizontalStartSpeed;

        rigidBody = gameObject.GetComponent<Rigidbody>();
	}

        // Updates every frame
	void Update ()
    {
        if (GameManager.instance.GetGameState() == EGameState.GS_Started)
        {
            SetSpeed();

            transform.Rotate(new Vector3(0f, 45f, 0f) * Time.deltaTime);

            if (Input.GetButtonDown("Gravity") && (bTouchedPlatform || gravityChangers > 0))
                ChangeGravity();
        }

    }
    
        // Updates at the end of every frame
    void FixedUpdate()
    {
        if (GameManager.instance.GetGameState() == EGameState.GS_Started)
        {
            Move();
        }
    }
    
        // Called when the ball touches something
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            bTouchedPlatform = true;
            AddPoints(20);
        }
    }

        // Called when the ball enters a trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
            AddPoints(10);
    }

    /***************************************************************************************************/

    public void AddPoints(int points) { score += points; }
    public void AddGravityChangers(int amount) { gravityChangers += amount; }

    public int GetScore() { return score; }
    public int GetGravityChangers() { return gravityChangers; }

    /***************************************************************************************************/

        // Moves ball horizontaly
    private void Move()
    {
        Vector3 movement = new Vector3(horizontalSpeed, 0f, 0f) * Time.deltaTime;

        rigidBody.MovePosition(transform.position + movement);
    }
    
        // Flips gravity
    private void ChangeGravity()
    {
        float gravity = Physics.gravity.y;
        gravity *= -1;
        Physics.gravity = new Vector3(0f, gravity);

        if (!bTouchedPlatform)
            gravityChangers--;
        else
            bTouchedPlatform = false;
    }

        // Sets ball's speed
    private void SetSpeed()
    {
        horizontalSpeed = horizontalStartSpeed + (score * horizontalAcceleration);
        if (horizontalSpeed >= horizontalMaxSpeed)
            horizontalSpeed = horizontalMaxSpeed;
    }
}
