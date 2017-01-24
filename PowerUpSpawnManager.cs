using UnityEngine;
using System.Collections;
        //spawns power-ups
public class PowerUpSpawnManager : MonoBehaviour {

    public GameObject[] m_SpawnPoints;
    public GameObject m_powerUp;
    public int m_powerUpOdds;       //defines probability of spawning power-up. Odds are 1 : m_powerUpOdds

    public void SpawnPowerUp()
    {
        int randomNum = Random.Range(0, m_powerUpOdds);

        if (randomNum == 0)
        {
            int spawnPointsNum = m_SpawnPoints.Length;

            randomNum = Random.Range(0, spawnPointsNum);
            Transform spawnPoint = m_SpawnPoints[randomNum].transform;

            Instantiate(m_powerUp, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
