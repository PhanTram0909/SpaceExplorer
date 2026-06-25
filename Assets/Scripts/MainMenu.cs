using UnityEngine;
using UnityEngine.SceneManagement; // Bắt buộc phải có dòng này để quản lý chuyển cảnh

public class MainMenu : MonoBehaviour
{
    // Hàm này sẽ kích hoạt khi người chơi nhấn nút
    public void LoadGameScene()
    {
        // Thay chữ "GameplayScene" bằng TÊN CHÍNH XÁC của Scene màn chơi tiếp theo của bạn
        SceneManager.LoadScene("GameplayScene");
    }
}