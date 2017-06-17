using UnityEngine;
using System.Collections;
    
public class GameSpace : MonoBehaviour {

    public AudioClip deathSound;

    private int destroyedPlatforms = 0;

        // Called when an object exits GameSpace
	void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerDeath(other.gameObject));
        }
        else
        {
            if(other.gameObject.CompareTag("Platform"))
                destroyedPlatforms++;

            Destroy(other.gameObject);
        }
    }

    /***************************************************************************************************/

    public int GetDestroyedPlatforms()
    {
        return destroyedPlatforms;
    }

    public void SetDestroyedPlatforms(int value)
    {
        destroyedPlatforms = value;
    }

    /***************************************************************************************************/

    private IEnumerator PlayerDeath(GameObject ball)
    {
        ball.SetActive(false);

        SoundManager.instance.PlaySound(deathSound);

        yield return new WaitForSeconds(1);

        GameManager.instance.OnPlayerDeath();
    }
}
