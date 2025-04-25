using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction = Vector3.down; // پیش‌فرض برای حرکت به پایین
    public float speed = 5f;
    public System.Action destroyed;
    private PointManager pointManager;

    private void Start()
    {
   pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    private void Update()
    {
        // حرکت در جهت مشخص با سرعت معین
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {


            if (pointManager != null)
            {
                pointManager.UpdateScore(50);
            }
            else
            {
                Debug.LogWarning(
                    "PointManager is null! Check if the GameObject is named correctly and has the script attached.");
            }
        }

        // اگر رویداد destroyed تعریف شده بود، فراخوانی‌اش کن
        this.destroyed?.Invoke();
        // حذف شیء (موشک)
        Destroy(this.gameObject);
    }
}

