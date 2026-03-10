using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float baseSpawnRate = 2f; // Başlangıç üretim hızı
    public float currentSpawnRate;
    public float obstacleSpeed = 5f; // Başlangıç hareket hızı
    
    private float timer = 0f;

    void Start()
    {
        currentSpawnRate = baseSpawnRate;
    }

    void Update()
    {
        if (BirdController.instance != null && BirdController.instance.isDead) return;

        // ZORLUK AYARI: Skora göre hızı artır
        // Her 5 puanda bir hızı %10 artır gibi bir mantık kuralım
        if (GameManager.instance != null)
        {
            int score = GameManager.instance.score;
            // Zorluk katsayısı (Skor arttıkça artan bir çarpan)
            float difficultyMultiplier = 1f + (score / 10f); 
            
            // Borular daha hızlı hareket etsin
            obstacleSpeed = 5f * difficultyMultiplier;
            
            // Borular daha sık gelsin (Ama çok da abartmayalım, minimum 0.8s olsun)
            currentSpawnRate = Mathf.Max(0.8f, baseSpawnRate / difficultyMultiplier);
        }

        if (timer < currentSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        float lowestPoint = transform.position.y - 2f;
        float highestPoint = transform.position.y + 2f;
        
        GameObject newObstacle = Instantiate(obstaclePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        
        // Ürettiğimiz boruya güncel hızı gönderiyoruz
        newObstacle.GetComponent<ObstacleScript>().moveSpeed = obstacleSpeed;
    }
}