using UnityEngine;
using UnityEngine.UI;

public class PowerUpIconHandler : MonoBehaviour
{
    [SerializeField] private Image shieldIcon;
    [SerializeField] private Image doubleScoreIcon;
    [SerializeField] private Image tripleShotIcon;

    private void Update()
    {
        ToggleShieldIcon();
        ToggleDoubleScoreIcon();
        ToggleTripleShotIcon();
    }

    private void ToggleShieldIcon()
    {
        var color = shieldIcon.color;
        if (GameManager.instance.IsShieldEnabled)
        {
            color.a = 1.0f;
        }
        else
        {
            color.a = 0.2f;
        }
        shieldIcon.color = color;
    }

    private void ToggleDoubleScoreIcon()
    {
        var color = doubleScoreIcon.color;
        if (GameManager.instance.IsDoubleScoreEnabled)
        {
            color.a = 1.0f;
        }
        else
        {
            color.a = 0.2f;
        }
        doubleScoreIcon.color = color;
    }

    private void ToggleTripleShotIcon()
    {
        var color = tripleShotIcon.color;
        if (GameManager.instance.IsTripleShotEnabled)
        {
            color.a = 1.0f;
        }
        else
        {
            color.a = 0.2f;
        }
        tripleShotIcon.color = color;
    }
}