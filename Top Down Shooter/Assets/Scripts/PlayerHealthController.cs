using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private GameObject deathVFX;

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
        
        FindObjectOfType<SceneLoader>().LoadGameOver();
        

        SoundManager.instance.PlayOneShotSFX(deathSFX);

        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.Euler(0f, 0f, -90f));
        Destroy(explosion, 1f);

        Destroy(gameObject);
    }

    public int GetPlayerHealth()
    {
        return health;
    }
}