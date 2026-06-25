using UnityEngine;
using UnityEngine.SceneManagement; // Bắt buộc phải có dòng này để chuyển màn

public class ButtonMoveController : MonoBehaviour
{
    [Header("Scene Target")]
    public string targetSceneName = "TAP TO START"; 

    // Hàm public để Button có thể nhìn thấy và gọi ra
    public void TriggerMoveScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogError("Ban chua dien ten Scene muc tieu trong Inspector!");
        }
    }
}