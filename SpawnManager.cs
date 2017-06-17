using UnityEngine;
using System.Collections;
    // Spawns platforms
public class SpawnManager : MonoBehaviour
{
    public GameObject platform;

    private float platformHorizontalMinDistance = 5.0f;     // Minimum horizontal distance from the last platform for a platform which is being spawned
    private float platformHorizontalMaxDistance = 10.0f;    // Maximum horizontal distance from the last platform for a platform which is being spawned
    private float platformVerticalMin = -5.0f;              // Minimum Y axis value for a platform which is being spawned
    private float platformVerticalMax = 5.0f;               // Maximum Y asis value for a platform which is being spawned

    private Vector3 lastPlatformPosition;                   // Position of the last spawned platform

    /***************************************************************************************************/

    // Called when game starts
    public void StartGame(Transform firstPlatformPosition)
    {
        lastPlatformPosition = firstPlatformPosition.position;

        SpawnPlatformsWave(20);
    }

        // Spawns given number of platforms in front of player
    public void SpawnPlatformsWave(int amount = 10)
    {
        Vector3 randomPosition;

        for (int i = 0; i < amount; i++)
        {
            randomPosition = new Vector3(Random.Range(lastPlatformPosition.x + platformHorizontalMinDistance, lastPlatformPosition.x + platformHorizontalMaxDistance),
                                            Random.Range(platformVerticalMin, platformVerticalMax));

            Instantiate(platform, randomPosition, Quaternion.identity);
            lastPlatformPosition = randomPosition;
        }
    }     
}
