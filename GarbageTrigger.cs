using UnityEngine;
using System.Collections;
        //destroys objects which are far behind the ball and spawns new platforms in front of it
public class GarbageTrigger : MonoBehaviour {

    public PlatformSpawnManager m_spawnManager;

    private int m_collectedPlatforms = 0;

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Destroy(other.gameObject);

            m_collectedPlatforms++;

            if(m_collectedPlatforms >= 10)
            {
                m_spawnManager.SpawnPlatforms();

                m_collectedPlatforms = 0;
            }
        }
        else if(other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
