using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action onGameOver;
    public event Action onVictory;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.collider.isTrigger = true;
            onGameOver?.Invoke();
        }
    }
}
