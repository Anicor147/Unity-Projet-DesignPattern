using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private float timer;
    private float timerInterval = 3f;
    [SerializeField] private ObjectPool objectPool;
    private static Spawn instance;
    

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(this);
    }
    
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
        enemy.transform.SetPositionAndRotation(spawnPoints[RandomIndex].position, spawnPoints[RandomIndex].rotation);
        enemy.gameObject.SetActive(true);
        
    }
}
