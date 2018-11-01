using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> bossPrefabs;
    [SerializeField] private List<GameObject> pathPrefabs;

    [SerializeField] private float minTimeBetweenSpawns;
    [SerializeField] private float maxTimeBetweenSpawns;

    [SerializeField] private int enemiesToSpawn;
    [SerializeField] private bool isLooping;

    private IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllEnemiesCoroutine());
        }
        while (isLooping);
    }

    private IEnumerator SpawnAllEnemiesCoroutine()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            string randomEnemyTag = randomEnemy.name;
            var randomPath = pathPrefabs[Random.Range(0, pathPrefabs.Count)];

            List<Transform> waypoints = GetWaypoints(randomPath);

            var enemy = PoolManager.instance.SpawnObjectFromPool(randomEnemyTag, waypoints[0].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyPathing>().SetWaypoints(waypoints);

            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
        }
    }

    private List<Transform> GetWaypoints(GameObject randomPath)
    {
        var waypoints = new List<Transform>();

        foreach (Transform child in randomPath.transform)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }
}