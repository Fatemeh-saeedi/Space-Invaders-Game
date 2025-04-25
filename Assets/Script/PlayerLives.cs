using UnityEngine;
using UnityEngine.UI;

public class PlayerLives:MonoBehaviour
{
public int lives = 3;
public Image[] livesUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            Destroy(other.gameObject);
            lives-=1;
            GameManager.Instance.PlayerHit();
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

}
