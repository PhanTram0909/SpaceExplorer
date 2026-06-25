using UnityEngine;

public class PlanetMovement2D : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    // HÀM VA CHẠM ĐÃ ĐƯỢC ĐỒNG BỘ VỚI MENU END GAME
    private void OnTriggerEnter2D(Collider2D other)
    {
        string nameLower = other.gameObject.name.ToLower();

        // 1. Đạn chạm vào hành tinh -> Cộng điểm và cả 2 bốc hơi
        if (nameLower.Contains("bullet"))
        {
            // TỰ ĐỘNG GỌI ĐẾN GAMEMANAGER ĐỂ CỘNG 10 ĐIỂM KHI DIỆT ĐƯỢC QUÁI
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(10);
            }

            Destroy(other.gameObject); // Xóa viên đạn
            Destroy(gameObject);       // Xóa hành tinh này
            return;
        }

        // 2. Hành tinh đâm trúng tàu Player -> Kích hoạt End Game Panel và hiện điểm đồ
        if (nameLower.Contains("player"))
        {
            Debug.Log("GAME OVER - Đâm trúng tàu!");

            // Gọi ông trọng tài kích hoạt màn hình End Game
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }

            Destroy(other.gameObject); // Xóa tàu Player
        }
    }
}