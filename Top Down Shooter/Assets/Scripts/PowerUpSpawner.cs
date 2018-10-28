using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpPrefabs;
    [SerializeField] [Range(1, 100)] private int chanceToSpawn;

    public void SpawnPowerUp(Vector2 spawnPosition)
    {
        if (Random.Range(0, 100) < chanceToSpawn)
        {
            var randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[randomPowerUp], spawnPosition, Quaternion.identity);
        }
    }
}