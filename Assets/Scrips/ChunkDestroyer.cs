using UnityEngine;

public class ChunkDestroyer : MonoBehaviour
{
    public GameObject chunk;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lava"))
        {
            Destroy(chunk);
            Debug.Log("Destroy Chunk");
        }
    }
}