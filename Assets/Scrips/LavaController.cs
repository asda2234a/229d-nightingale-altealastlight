using UnityEngine;

public class LavaController : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}