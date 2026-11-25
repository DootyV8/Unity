using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public int maxEnemies = 10;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            int currentEnemies = FindObjectsOfType<EnemyAI>().Length;

            if (currentEnemies < maxEnemies && enemyPrefab != null)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
            }
        }
    }
}