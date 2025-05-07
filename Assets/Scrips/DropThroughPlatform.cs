using UnityEngine;

public class DropThroughPlatform : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    private PolygonCollider2D playerTrigger;

    public float resetTime = 0.6f;

    private bool canDrop = false;
    private bool isColliderDisabled = false;

    void Start()
    {
        // หาผู้เล่นและเก็บ collider มาครั้งเดียว
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerCollider = player.GetComponent<BoxCollider2D>();
            playerTrigger = player.GetComponent<PolygonCollider2D>();
        }
        else
        {
            Debug.LogError("Player with tag 'Player' not found in scene!");
        }
    }

    void Update()
    {
        if (playerCollider == null || playerTrigger == null)
            return; // ถ้ายังหาไม่เจอ ให้ออกจาก Update ไปก่อน

        // เมื่อกด S + Space และอยู่ในแพลตฟอร์ม → ปิด collider
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space) && canDrop && !isColliderDisabled)
        {
            DisablePlayerCollider();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canDrop = true;
            Debug.Log("Player on platform. Can drop: " + canDrop);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canDrop = false;
            Debug.Log("Player exited platform. Can drop: " + canDrop);

            // ถ้าเคยปิด collider มาก่อน → เปิดกลับเมื่อออกนอก trigger
            if (isColliderDisabled)
            {
                EnablePlayerCollider();
            }
        }
    }

    void DisablePlayerCollider()
    {
        playerCollider.enabled = false;
        isColliderDisabled = true;
        Debug.Log("Player collider disabled.");
    }

    void EnablePlayerCollider()
    {
        playerCollider.enabled = true;
        isColliderDisabled = false;
        Debug.Log("Player collider enabled.");
    }
}
