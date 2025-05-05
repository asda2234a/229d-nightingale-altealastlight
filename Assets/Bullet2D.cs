using UnityEngine;

public class Bullet2D : MonoBehaviour
{
    public float maxDistance = 20f; // ระยะทางสูงสุดที่กระสุนจะอยู่
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float traveled = Vector2.Distance(startPosition, transform.position);
        if (traveled > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            Debug.Log("TarGet Hit Do Damage");
        }

        // ถ้าชนอะไรก็ทำลายตัวเอง
        Destroy(gameObject);
    }
}

