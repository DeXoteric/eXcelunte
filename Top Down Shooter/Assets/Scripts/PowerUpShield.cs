using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    [SerializeField] private float powerUpSpeed;
    [SerializeField] private int scoreValue;

    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -powerUpSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.AddToScore(scoreValue);
            GameManager.instance.IsShieldEnabled = true;
            FindObjectOfType<PlayerPowerUpController>().ResetShieldTimer();
        }
        Destroy(gameObject);
    }
}