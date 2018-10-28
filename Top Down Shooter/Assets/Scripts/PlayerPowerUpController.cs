using UnityEngine;

public class PlayerPowerUpController : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip pickUpSFX;

    [Header("Shield")]
    [SerializeField] private GameObject shield;
    [SerializeField] private float shieldTimer;
    private float currentShieldTimer;

    [Header("Double Score")]
    [SerializeField] private float doubleScoreTimer;
    private float currentDoubleScoreTimer;

    [Header("Triple Shot")]
    [SerializeField] private float tripleShotTimer;
    private float currentTripleShotTimer;

    private void Update()
    {
        ToggleTripleShot();
        ToggleDoubleScore();
        ToggleShield();
    }

    private void ToggleTripleShot()
    {
        if (GameManager.instance.IsTripleShotEnabled)
        {
            currentTripleShotTimer -= Time.deltaTime;
            if (currentTripleShotTimer <= 0)
            {
                GameManager.instance.IsTripleShotEnabled = false;
            }
        }
        else
        {
            ResetTripleShotTimer();
        }
    }

    public void ResetTripleShotTimer()
    {
        currentTripleShotTimer = tripleShotTimer;
    }

    private void ToggleDoubleScore()
    {
        if (GameManager.instance.IsDoubleScoreEnabled)
        {
            currentDoubleScoreTimer -= Time.deltaTime;
            if (currentDoubleScoreTimer <= 0)
            {
                GameManager.instance.IsDoubleScoreEnabled = false;
            }
        }
        else
        {
            ResetDoubleScoreTimer();
        }
    }

    public void ResetDoubleScoreTimer()
    {
        currentDoubleScoreTimer = doubleScoreTimer;
    }

    private void ToggleShield()
    {
        if (GameManager.instance.IsShieldEnabled)
        {
            shield.SetActive(true);

            currentShieldTimer -= Time.deltaTime;
            if (currentShieldTimer <= 0)
            {
                GameManager.instance.IsShieldEnabled = false;
            }
        }
        else
        {
            ResetShieldTimer();
            shield.SetActive(false);
        }
    }

    public void ResetShieldTimer()
    {
        currentShieldTimer = shieldTimer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerUp")
        {
            SoundManager.instance.PlayOneShotSFX(pickUpSFX);
        }
    }
}