using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }
}