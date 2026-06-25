using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Bắt buộc phải có để load lại màn chơi

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Giao diện Chơi Game")]
    public TextMeshProUGUI scoreText; // Chữ tính điểm lúc đang chơi
    private int score = 0;

    [Header("Giao diện Thua Cuộc")]
    public GameObject endGamePanel;      // Kéo EndGamePanel vào đây
    public TextMeshProUGUI finalScoreText; // Kéo FinalScoreText vào đây

    void Awake()
    {
        instance = this;
        Time.timeScale = 1f; // Đảm bảo game chạy bình thường lúc mới vào
    }

    // Hàm cộng điểm lúc đang chơi
    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // HÀM KÍCH HOẠT KHI THUA CUỘC
    public void GameOver()
    {
        // 1. Hiện màn hình End Game lên
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
        }

        // 2. Cập nhật điểm số cuối cùng đạt được
        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + score;
        }

        // 3. Đóng băng màn hình game lại (Hành tinh dừng di chuyển, tàu dừng bắn)
        Time.timeScale = 0f;
    }

    // HÀM DÀNH CHO NÚT RESTART BẤM VÀO
    public void RestartGame()
    {
        // Load lại chính cái màn chơi hiện tại từ đầu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}