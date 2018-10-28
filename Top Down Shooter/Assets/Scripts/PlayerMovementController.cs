using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float padding;

    private float xMin, xMax, yMin, yMax;
    private float deltaX, deltaY;
    private float screenWidth;

    private void Start()
    {
        SetUpMoveBoundaries();
        screenWidth = Screen.width;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!GameManager.instance.IsOnMobile)
        {
            deltaX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        }
        else if (GameManager.instance.IsOnMobile)
        {
            int i = 0;
            deltaX = 0 * moveSpeed * Time.deltaTime;
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x > screenWidth / 2)
                {
                    deltaX = 1 * moveSpeed * Time.deltaTime;
                }
                else if (Input.GetTouch(i).position.x < screenWidth / 2)
                {
                    deltaX = -1 * moveSpeed * Time.deltaTime;
                }
                ++i;
            }
        }

        deltaY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        var newXPosition = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPosition = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPosition, newYPosition);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameGamera = Camera.main;
        xMin = gameGamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameGamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameGamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameGamera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y - padding;
    }
}