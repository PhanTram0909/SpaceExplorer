using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // Kéo tàu Player vào đây
    public float smoothSpeed = 0.125f; // Độ mượt của camera
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Giữ khoảng cách trục Z để camera không đè sát vào tàu

    void LateUpdate()
    {
        if (target == null) return;

        // Tính toán vị trí camera cần tới
        Vector3 desiredPosition = target.position + offset;
        // Di chuyển mượt mà tới vị trí đó
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}