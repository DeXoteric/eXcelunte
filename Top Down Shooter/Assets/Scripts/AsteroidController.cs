using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int scoreValue;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private float asteroidMinSpeed;
    [SerializeField] private float asteroidMaxSpeed;
    [SerializeField] private float rotationSpeed;

    private int currentHealth;
    private float moveSpeed;
    private int rotationDirection;

    private float explosionDuration = 1f;

    private void Start()
    {
        currentHealth = health;
        moveSpeed = Random.Range(asteroidMinSpeed, asteroidMaxSpeed);

        if (Random.Range(0, 2) == 0)
        {
            rotationDirection = -1;
        }
        else
        {
            rotationDirection = 1;
        }
    }

    private void Update()
    {
        MoveAsteroid();
        RotateAsteroid();
    }

    private void MoveAsteroid()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed * Time.deltaTime);

        if (gameObject.transform.position.y <= -11f)
        {
            gameObject.transform.position = new Vector2(Random.Range(-5f, 5f), 11f);
            currentHealth = health;
        }
    }

    private void RotateAsteroid()
    {
        transform.Rotate(0, 0, rotationDirection * rotationSpeed * Time.deltaTime);
    }

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
        currentHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameManager.instance.AddToScore(scoreValue);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity) as GameObject;
        SoundManager.instance.PlayOneShotSFX(deathSFX);
        Destroy(explosion, explosionDuration);
    }
}