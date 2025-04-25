using UnityEngine;
using TMPro;

public class Bunker : MonoBehaviour
{
    public int Health = 5;
    public TMP_Text healthText;

    private void Start()
    {
        UpdateHealthDisplay();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            Destroy(other.gameObject);
            Health -= 1;
            UpdateHealthDisplay();

            if (Health <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            healthText.text = Health.ToString();
        }
    }
}

