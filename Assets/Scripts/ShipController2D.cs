using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 8f;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;   // Kéo mẫu viên đạn Prefab vào đây
    public Transform firePoint;       // Kéo GameObject vị trí bắn đạn ở mũi tàu vào đây

    // ĐÃ CHỈNH LẠI: Tăng thời gian chờ lên 0.5 giây để đạn xả chậm lại, từng viên một
    public float fireRate = 0.5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float nextFireTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        if (firePoint == null) firePoint = this.transform;
    }

    void Update()
    {
        // 1. ĐỌC PHÍM DI CHUYỂN TÀU (Giữ nguyên mượt mà)
        if (UnityEngine.InputSystem.Keyboard.current != null)
        {
            var keyboard = UnityEngine.InputSystem.Keyboard.current;
            float moveX = 0f;
            float moveY = 0f;

            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) moveY = 1f;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) moveY = -1f;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) moveX = 1f;
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) moveX = -1f;

            moveInput = new Vector2(moveX, moveY).normalized;
        }

        // 2. TỰ ĐỘNG BẮN LIÊN TỤC THEO NHỊP (Bỏ check phím Space)
        // Cứ đủ thời gian hồi (fireRate) là tự động phun đúng 1 viên đạn
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Cài đặt thời gian cho viên tiếp theo
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Sinh ra đúng 1 viên đạn duy nhất tại vị trí họng súng
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }

    // XỬ LÝ VA CHẠM CỨNG: Khi hành tinh đâm trúng tàu -> Hiện End Game UI
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            Debug.Log("GAME OVER - Tàu đã bị hành tinh đâm nổ!");

            // Gọi ông trọng tài kích hoạt màn hình End Game, hiện điểm đồ
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }

            Destroy(gameObject); // Xóa tàu
        }
    }

    // XỬ LÝ VA CHẠM XUYÊN QUA (TRIGGER): Phòng hờ nếu hành tinh đang để Is Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            Debug.Log("GAME OVER - Tàu đã bị hành tinh đâm nổ!");

            // Gọi ông trọng tài kích hoạt màn hình End Game, hiện điểm đồ
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }

            Destroy(gameObject); // Xóa tàu
        }
    }
}