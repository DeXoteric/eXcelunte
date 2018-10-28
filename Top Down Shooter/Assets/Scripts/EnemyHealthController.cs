using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int scoreValue;
    [SerializeField] private GameObject[] deathVFX;
    [SerializeField] private AudioClip deathSFX;

    private float explosionDuration = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);

        GameManager.instance.AddToScore(scoreValue);

        var randomExplosion = deathVFX[Random.Range(0, deathVFX.Length)];
        GameObject explosion = Instantiate(randomExplosion, transform.position, Quaternion.identity) as GameObject;

        SoundManager.instance.PlayOneShotSFX(deathSFX);

        Destroy(explosion, explosionDuration);

        FindObjectOfType<PowerUpSpawner>().SpawnPowerUp(gameObject.transform.position);
    }
}