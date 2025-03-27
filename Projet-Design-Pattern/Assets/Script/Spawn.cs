using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    private Enemy enemy;
    private float timer;
    
        
    void Start()
    {
     
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0) SpawnEnnemies();
        }
    }

    private void SpawnEnnemies()
    {
        
    }
}
