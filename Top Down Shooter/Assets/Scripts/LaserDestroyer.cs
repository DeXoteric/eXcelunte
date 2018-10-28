using UnityEngine;

public class LaserDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            //Destroy(collision.gameObject);

            collision.gameObject.SetActive(false);
        }
    }
}