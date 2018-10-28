using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.text = GameManager.instance.GetScore().ToString();
    }
}