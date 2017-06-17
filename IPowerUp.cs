using UnityEngine;
using System.Collections;
        // Takes care of power-ups
public abstract class IPowerUp : MonoBehaviour {

    public AudioClip powerUpSound;

            // Updates every frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 45f) * Time.deltaTime);
    }

            // Called when power-ups collides with something
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LaunchSpecialPower(other.gameObject.GetComponent<Ball>());

            SoundManager.instance.PlaySound(powerUpSound);

            Destroy(gameObject);
        }
    }

    /***************************************************************************************************/

    // Launches power-ups special ability
    protected abstract void LaunchSpecialPower(Ball ball);
}
