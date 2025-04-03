using UnityEngine;

using System;
public class EventManager : MonoBehaviour
{
    public event Action<int> onEnemyDeath;
    public event Action<int> onShield;
    public event Action<int> onIncreaseShield;

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

    public void TriggerOnShield(int value)
    {
        onShield?.Invoke(value);
    }

    public void TriggerOnIncreaseShield(int value)
    {
        onIncreaseShield?.Invoke(value);
    }
}
