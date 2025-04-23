using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction = Vector3.down; // پیش‌فرض برای حرکت به پایین
    public float speed = 5f;
    public System.Action destroyed;

    private void Update()
    {
        // حرکت در جهت مشخص با سرعت معین
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // اگر رویداد destroyed تعریف شده بود، فراخوانی‌اش کن
        this.destroyed?.Invoke();

        // حذف شیء (موشک)
        Destroy(this.gameObject);
    }
}

