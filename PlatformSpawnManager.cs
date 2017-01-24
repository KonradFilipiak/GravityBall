using UnityEngine;
using System.Collections;
//spawns platforms
public class PlatformSpawnManager : MonoBehaviour
{

    public Transform m_firstPlatform;
    public GameObject m_platform;

    public int m_maxPlatforms;      //how many platforms do we want to spawn at once

    //min and max distances from the last platform
    public float m_horizontalMin;
    public float m_horizontalMax;
    public float m_verticalMin;
    public float m_verticalMax;

    private Vector3 m_lastPlatformPos;
            //sets last platform position to the first one and spaws 2 sets of platforms
    void Start()
    {
        m_lastPlatformPos = m_firstPlatform.position;

        SpawnPlatforms();
        SpawnPlatforms();
    }
            //spawns 'm_maxPlatforms' platforms
    public void SpawnPlatforms()
    {
        Vector3 randomPosition;

        for (int i = 0; i < m_maxPlatforms; i++)
        {
            randomPosition = new Vector3(Random.Range(m_lastPlatformPos.x + m_horizontalMin, m_lastPlatformPos.x + m_horizontalMax), Random.Range(m_verticalMin, m_verticalMax), 0);

            GameObject platform = Instantiate(m_platform, randomPosition, Quaternion.identity) as GameObject;
            m_lastPlatformPos = randomPosition;

                    //spawns power-up on platform
            PowerUpSpawnManager powerUpSpawn = platform.GetComponent<PowerUpSpawnManager>();
            powerUpSpawn.SpawnPowerUp();
        }
    }
}
