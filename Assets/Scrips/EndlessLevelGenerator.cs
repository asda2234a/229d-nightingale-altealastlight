using UnityEngine;

public class EndlessLevelGenerator : MonoBehaviour
{
    public Transform player;
    public float chunkWidth = 10f;
    public float spawnDistanceAhead = 20f;
    private float nextSpawnX = 0f;

    public GameObject[] chunkPrefabs;

    void Start()
    {
        // โหลด Chunk Prefabs จาก Resources (ถ้าไม่ใช้ Resources ให้ assign ด้วยมือ)
        if (chunkPrefabs == null || chunkPrefabs.Length == 0)
        {
            chunkPrefabs = Resources.LoadAll<GameObject>("Chunks");
        }

        // เริ่มต้นด้วย 3 ชิ้น
        for (int i = 0; i < 3; i++) SpawnChunk();
    }

    void Update()
    {
        // ถ้าผู้เล่นใกล้ถึงตำแหน่ง spawn ต่อไป
        if (player.position.x + spawnDistanceAhead > nextSpawnX)
        {
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        GameObject prefab = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
        Instantiate(prefab, new Vector3(nextSpawnX, 0, 0), Quaternion.identity);
        nextSpawnX += chunkWidth;
    }
}
