using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMeshProUGUI pauseText;
    private bool isPause = false;
    private bool isDie = false;

    private bool isGameOver = false;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Retry();
        }
    }

    public void TriggerGameOver()
    {
        isDie = true;
        pauseText.text = "Game Over";
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;  // หยุดเกม
        isGameOver = true;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Scene");  // ใส่ชื่อ Scene เมนูของคุณ
    }

    public void PauseGame()
    {
        if (isPause == false && isDie != true)
        {
            isPause = true;
            pauseText.text = "   Pause";
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }
        else if (isPause == true && isDie != true)
        {
            isPause = false;
            Time.timeScale = 1f;
            gameOverUI.SetActive(false);
        }
    }
}