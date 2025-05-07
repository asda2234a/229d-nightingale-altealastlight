using System.Collections;
using UnityEngine;

public class DropThroughPlatform : MonoBehaviour
{
    private Collider2D playerCollider;
    public float resetTime = 0.5f;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DisableColliderTemporarily());
        }
    }

    IEnumerator DisableColliderTemporarily()
    {
        playerCollider.enabled = false;
        yield return new WaitForSeconds(resetTime);  // เวลาที่ให้ร่างกายทะลุลง (ปรับได้)
        playerCollider.enabled = true;
    }
}
