using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Projectile laserPrefab;
    public float speed = 7.0f;

    private bool _laserActive;

    private void Update()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
        }

        Vector3 position = this.transform.position;
        position.x += moveInput * this.speed * Time.deltaTime;

        // گرفتن حدود چپ و راست دوربین
        float screenLeft = Camera.main.ViewportToWorldPoint(Vector3.zero).x + 0.5f;  // لبه چپ
        float screenRight = Camera.main.ViewportToWorldPoint(Vector3.right).x - 0.5f; // لبه راست

        // محدود کردن حرکت بازیکن بین این دو مقدار
        position.x = Mathf.Clamp(position.x, screenLeft, screenRight);

        this.transform.position = position;

        // شلیک
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!_laserActive)
        {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") ||
            other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
          
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}