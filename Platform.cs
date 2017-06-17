using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    public Transform[] powerUpSpawnPoints;
    public IPowerUp[] powerUps;

    public float powerUpChanceToSpawn;             // Percentage chance to spawn a power-up on a platform

    void Start()
    {
        if (IsSpawningPowerUp())
        {
            int randomSpawnPoint = Random.Range(0, powerUpSpawnPoints.Length);
            int randomPowerUp = Random.Range(0, powerUps.Length);

            Instantiate(powerUps[randomPowerUp],
                        powerUpSpawnPoints[randomSpawnPoint].position,
                        powerUpSpawnPoints[randomSpawnPoint].rotation);
        }
    }

    /***************************************************************************************************/

    // Called to decide wether a platform has a power-up or not
    private bool IsSpawningPowerUp()
    {
        if (Random.Range(0.0f, 100.0f) < powerUpChanceToSpawn)
            return true;

        return false;
    }
}
