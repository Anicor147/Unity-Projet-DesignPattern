using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private Player player;


    private void Start()
    {
        victoryText.SetActive(false);
        gameOverText.SetActive(false);
        
        player.onGameOver += OnGameOver;
        player.onVictory += OnVictory;
    }

    private void Update()
    {
        
    }

    private void OnVictory()
    {
        victoryText.SetActive(true);
    }

    private void OnGameOver()
    {
        gameOverText.SetActive(true);
    }

    private void OnDisable()
    {
        player.onGameOver -= OnGameOver;
        player.onVictory -= OnVictory;
    }
}
