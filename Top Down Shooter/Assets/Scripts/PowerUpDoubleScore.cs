using UnityEngine;

public class PowerUpDoubleScore : MonoBehaviour
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
            GameManager.instance.DoubleScoreMultiplier += 1;

            //TODO add feedback to player

            GameManager.instance.AddToScore(scoreValue);
            GameManager.instance.IsDoubleScoreEnabled = true;
            FindObjectOfType<PlayerPowerUpController>().ResetDoubleScoreTimer();
        }

        Destroy(gameObject);
    }
}