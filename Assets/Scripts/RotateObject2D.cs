using UnityEngine;

public class RotateObject2D : MonoBehaviour
{
    [Header("Tốc độ xoay (Số dương: Ngược chiều ĐH, Số âm: Thuận chiều ĐH)")]
    public float rotationSpeed = 50f;

    void Update()
    {
        // Xoay quanh trục Z (trục vuông góc với màn hình 2D) theo thời gian
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}