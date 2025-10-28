using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // สำหรับโหลดฉากใหม่

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton

    public GameObject gameOverPanel;

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // ปิดไว้ก่อนเสมอ
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true); // แสดง Panel
        Time.timeScale = 0f; // หยุดเวลาเกม
    }

    public void RestartGame()
    {
    Debug.Log("Restart button clicked");
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void HideGameOverPanel()
    {
    if (gameOverPanel != null)
        gameOverPanel.SetActive(false);
    }

}
