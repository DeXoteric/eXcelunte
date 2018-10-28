using System.Collections;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private float laserSpeed;
    [SerializeField] private float laserFiringPeriod;

    [Header("Weapons")]
    [SerializeField] private GameObject middleWeapon;
    [SerializeField] private GameObject leftWeapon;
    [SerializeField] private GameObject rightWeapon;

    [Header("Audio")]
    [SerializeField] private AudioClip shootSFX;

    private Coroutine firingCoroutine;

    private void Start()
    {
        if (GameManager.instance.IsOnMobile || !GameManager.instance.IsOnMobile)
        {
            StartCoroutine(FireContinuosly());
        }
    }

    //private void Update()
    //{
    //    if (!GameManager.instance.IsOnMobile && GameManager.instance.GameStarted)
    //    {
    //        Fire();
    //    }
    //}

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinuosly()
    {
        while (true)
        {
            if (GameManager.instance.GameStarted)
            {
                if (GameManager.instance.IsTripleShotEnabled)
                {
                    FireAllWeapons();
                }
                else if (!GameManager.instance.IsTripleShotEnabled)
                {
                    FireMiddleWeapon();
                }
                SoundManager.instance.PlayOneShotSFX(shootSFX);
            }

            yield return new WaitForSeconds(laserFiringPeriod);
        }
    }

    private void FireAllWeapons()
    {
        FireMiddleWeapon();

        GameObject leftProjectile = PoolManager.instance.SpawnObjectFromPool("Player Laser", leftWeapon.transform.position, leftWeapon.transform.rotation);
        leftProjectile.GetComponent<Rigidbody2D>().velocity = leftProjectile.transform.up * laserSpeed * Time.deltaTime;

        GameObject rightProjectile = PoolManager.instance.SpawnObjectFromPool("Player Laser", rightWeapon.transform.position, rightWeapon.transform.rotation);
        rightProjectile.GetComponent<Rigidbody2D>().velocity = rightProjectile.transform.up * laserSpeed * Time.deltaTime;
    }

    private void FireMiddleWeapon()
    {
        GameObject middleProjectile = PoolManager.instance.SpawnObjectFromPool("Player Laser", middleWeapon.transform.position, middleWeapon.transform.rotation);
        middleProjectile.GetComponent<Rigidbody2D>().velocity = middleProjectile.transform.up * laserSpeed * Time.deltaTime;
    }
}