using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private EventManager eventManager;
    private float timer = 0;
    private int score = 0;
    
    
    private static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        victoryText.SetActive(false);
        gameOverText.SetActive(false);
        
        EventManager.Instance.onEnemyDeath += IncreaseScore;
        
        player.onGameOver += OnGameOver;
        player.onVictory += OnVictory;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timeText.text = timer.ToString("0.00");
    }

    private void OnVictory()
    {
        victoryText.SetActive(true);
    }

    private void OnGameOver()
    {
        gameOverText.SetActive(true);
    }

    private void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
    private void OnDisable()
    {
        player.onGameOver -= OnGameOver;
        player.onVictory -= OnVictory;
    }
}