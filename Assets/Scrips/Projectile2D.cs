using UnityEngine;
using Unity.Cinemachine;

public class Projectile2D : MonoBehaviour
{
    public Transform shootPoint;

    public GameObject target;

    public Rigidbody2D bulletPrefab;

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)

    {

        Vector2 distance = target - origin;

        float velocityX = distance.x / time;

        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);

    }//

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.magenta, 5f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);

                Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);

                Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

                firedBullet.linearVelocity = projectileVelocity;

            }//hit.collider

        }//GetMouseButtonDown
    }//upd
}//proj2d
