using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameOverManager gameOverManager;
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(player);
        }

        if (gameOverManager == null)
        {
            gameOverManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<GameOverManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Die");
            Die();
            Destroy(player);
        }
    }

    void Die()
    {
        gameOverManager.TriggerGameOver();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DestructibleObject destructible = collision.gameObject.GetComponent<DestructibleObject>();
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            destructible.TakeDamage(10000);
        }
    }
}
