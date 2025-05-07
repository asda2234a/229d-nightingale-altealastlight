using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = player.position;
    }

    void Update()
    {
        float distance = player.position.x - startPosition.x;
        int score = Mathf.FloorToInt(distance);
        score = Mathf.Max(score, 0); // ห้ามติดลบ
        
        scoreText.text = "Distance: " + score.ToString();
    }
}

