using UnityEngine;

using System;
public class EventManager : MonoBehaviour
{
    public event Action<int> onEnemyDeath;

    public static EventManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerOnEnemyDeath(int value)
    {
        onEnemyDeath?.Invoke(value);
    }
}
