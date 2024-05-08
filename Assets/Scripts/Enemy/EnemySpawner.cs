using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minSpawnTime;
    
    [SerializeField]
    private float maxSpawnTime;

    [SerializeField]
    private float timeUntilSpawn;

    // Start is called before the first frame update


    void Awake()
    {
        SetTimeUntilSpawn();
    }   

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn <= 0) 
        {

            Camera cam = GetComponentInChildren<Camera>();

            //Debug.Log(cam.pixelHeight);


            Instantiate(enemyPrefab, new Vector2(transform.position.x + 15, transform.position.y + Random.Range(-10,10)), Quaternion.identity);

            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
