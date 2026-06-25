using UnityEngine;

public class PlanetSpawner2D : MonoBehaviour
{
    public GameObject[] planetPrefabs; // Danh sách các hành tinh mẫu (Prefabs)
    public float spawnInterval = 2f;    // Cứ sau bao nhiêu giây thì sinh ra 1 hành tinh mới

    [Header("Spawn Position Settings")]
    public float spawnX = 15f;          // Tọa độ X ở rìa bên phải màn hình để tạo hành tinh
    public float minY = -5f;            // Tọa độ Y thấp nhất (rìa dưới màn hình)
    public float maxY = 5f;             // Tọa độ Y cao nhất (rìa trên màn hình)

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPlanet();
            timer = 0f; // Reset lại thời gian để đếm lượt tiếp theo
        }
    }

    void SpawnPlanet()
    {
        if (planetPrefabs.Length == 0) return;

        // 1. Chọn ngẫu nhiên một hành tinh trong danh sách Prefabs
        int randomIndex = Random.Range(0, planetPrefabs.Length);
        GameObject selectedPrefab = planetPrefabs[randomIndex];

        // 2. Tính toán vị trí xuất hiện: Cố định X ở bên phải, ngẫu nhiên chiều cao Y (lên hoặc xuống)
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);

        // 3. Tạo hành tinh ra màn hình game
        GameObject newPlanet = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        
    }
}