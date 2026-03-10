using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    // Spawner bu değeri Instantiate anında güncelleyecek
    public float moveSpeed = 5f; 

    void Update()
    {
        if (BirdController.instance != null && BirdController.instance.isDead) return;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}