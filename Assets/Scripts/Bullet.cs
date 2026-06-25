using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;   // Tốc độ bay
    public float lifeTime = 3f; // Thời gian tự hủy

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Ép đạn luôn tịnh tiến sang phải màn hình
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}