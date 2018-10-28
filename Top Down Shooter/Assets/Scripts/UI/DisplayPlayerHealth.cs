using TMPro;
using UnityEngine;

public class DisplayPlayerHealth : MonoBehaviour
{
    private TextMeshProUGUI playerHealthText;
    private PlayerHealthController playerHealthController;

    private void Start()
    {
        playerHealthText = GetComponent<TextMeshProUGUI>();
        playerHealthController = FindObjectOfType<PlayerHealthController>();
    }

    private void Update()
    {
        playerHealthText.text = playerHealthController.GetPlayerHealth().ToString();
    }
}