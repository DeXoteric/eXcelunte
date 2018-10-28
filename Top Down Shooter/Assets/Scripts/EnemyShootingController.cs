using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] private float minTimeBetweenShots;
    [SerializeField] private float maxTimeBetweenShots;
    [SerializeField] protected AudioClip shootSFX;

    private float shotCounter;

    private void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    protected virtual void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            Fire();

            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    protected virtual void Fire()
    {
        GameObject projectile = PoolManager.instance.SpawnObjectFromPool(projectilePrefab.name, transform.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * -projectileSpeed * Time.deltaTime;

        SoundManager.instance.PlayOneShotSFX(shootSFX);
    }
}