using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float timeUntilSpawn;
    public int enemyCount;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0 && enemyCount <= 100)
        {
            enemyCount++;

            Camera cam = GetComponentInChildren<Camera>();

            int randomX = Random.Range(0, 2);
            randomX = (randomX == 0) ? -15 : 15;

            int randomY = Random.Range(0, 2);
            randomY = (randomY == 0) ? -10 : 10;

            GameObject enemy = Instantiate(enemyPrefab, new Vector2(transform.position.x + randomX, transform.position.y + randomY), Quaternion.identity);
            enemy.AddComponent<DemonEnemy>();
            enemy.GetComponent<EnemyManager>().loadPlayerObject(this.gameObject);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
