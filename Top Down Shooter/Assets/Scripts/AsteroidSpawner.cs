using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float minTimeBetweenSpawn;
    [SerializeField] private float maxTimeBetweenSpawn;

    private float spawnYPosition = 11f;

    private IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAsteroid());
        }
        while (true);
    }

    private IEnumerator SpawnAsteroid()
    {
        var timeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        var randomAsteroid = Random.Range(0, asteroidPrefabs.Length);
        var spawnPosition = new Vector2(Random.Range(-5f, 5f), spawnYPosition);

        Instantiate(asteroidPrefabs[randomAsteroid], spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(timeBetweenSpawn);
    }
}