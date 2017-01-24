using UnityEngine;
using System.Collections;
        //ends the game (kills the player)
public class DeathTrigger : MonoBehaviour {

    public GameManager m_gameManager;
    public AudioClip m_deathSound;

	void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerDeath(other.gameObject));
        }
    }
            //sets ball unactive and updates UI
    private IEnumerator PlayerDeath(GameObject ball)
    {
        ball.SetActive(false);

        SoundManager.instance.PlaySound(m_deathSound);

        yield return new WaitForSeconds(1);

        m_gameManager.OnPlayerDeath();
    }
}
