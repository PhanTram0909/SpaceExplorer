using UnityEngine;
using UnityEngine.UI; // Bắt buộc phải có để thao tác với UI Image

public class BlinkingButton : MonoBehaviour
{
    [Header("Blinking Settings")]
    public float blinkSpeed = 2.0f; // Tốc độ nhấp nháy (càng cao càng nhanh)
    public float minAlpha = 0.3f;   // Độ mờ tối thiểu (0 là trong suốt hẳn, 1 là đậm đặc)
    public float maxAlpha = 1.0f;   // Độ đậm tối đa

    private Image buttonImage;
    private bool goingDown = true;
    private float currentAlpha;

    void Start()
    {
        // Tự động lấy component Image gắn trên nút
        buttonImage = GetComponent<Image>();
        if (buttonImage != null)
        {
            currentAlpha = maxAlpha;
        }
    }

    void Update()
    {
        if (buttonImage == null) return;

        // Tính toán tăng giảm độ mờ (Alpha) theo thời gian thực
        if (goingDown)
        {
            currentAlpha -= Time.deltaTime * blinkSpeed;
            if (currentAlpha <= minAlpha)
            {
                currentAlpha = minAlpha;
                goingDown = false; // Đổi chiều: bắt đầu sáng lên
            }
        }
        else
        {
            currentAlpha += Time.deltaTime * blinkSpeed;
            if (currentAlpha >= maxAlpha)
            {
                currentAlpha = maxAlpha;
                goingDown = true; // Đổi chiều: bắt đầu mờ đi
            }
        }

        // Áp dụng màu sắc và độ Alpha mới vào nút bấm
        Color imgColor = buttonImage.color;
        imgColor.a = currentAlpha;
        buttonImage.color = imgColor;
    }
}