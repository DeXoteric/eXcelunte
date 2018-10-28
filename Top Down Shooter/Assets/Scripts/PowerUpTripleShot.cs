using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTripleShot : MonoBehaviour {

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
            GameManager.instance.IsTripleShotEnabled = true;
            FindObjectOfType<PlayerPowerUpController>().ResetTripleShotTimer();

        }

        Destroy(gameObject);
    }
}
