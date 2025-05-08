using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject creditUi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("Play");
        creditUi.SetActive(false);
    }

    public void Credit()
    {
        creditUi.SetActive(true);
    }

    public void ExitCredit()
    {
        creditUi.SetActive(false);
    }

}
