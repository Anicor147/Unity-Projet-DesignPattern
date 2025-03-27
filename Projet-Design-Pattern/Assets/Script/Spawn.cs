using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private Transform[] spawnPoints;
    private float timer;
    private float timerInterval = 2f;
    [SerializeField] private ObjectPool objectPool;
    
        
    void Start()
    {
        timer = timerInterval;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SpawnEnemies();
                timer = timerInterval;
            }
        }
    }

    private void SpawnEnemies()
    {
        int RandomIndex = Random.Range(0, spawnPoints.Length);
        
        var enemy = objectPool.GetObject();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoints[RandomIndex].position;
    }
}
