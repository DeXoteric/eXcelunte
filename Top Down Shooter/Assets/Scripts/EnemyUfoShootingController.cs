using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUfoShootingController : EnemyShootingController {

    [SerializeField] private GameObject[] weapons;

    protected override void CountDownAndShoot()
    {
        base.CountDownAndShoot();
    }

    protected override void Fire()
    {
       foreach(GameObject weapon in weapons)
        {
            GameObject projectile = PoolManager.instance.SpawnObjectFromPool(projectilePrefab.name, weapon.transform.position, weapon.transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * projectileSpeed * Time.deltaTime;
        }

        SoundManager.instance.PlayOneShotSFX(shootSFX);
    }
}
