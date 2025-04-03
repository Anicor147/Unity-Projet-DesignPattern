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
    [SerializeField] private TMP_Text shieldChargeText;
    private float timer = 0;
    private int score = 0;
    private int charge = 2;
    
    
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
        EventManager.Instance.onShield += OnShieldUp;
        EventManager.Instance.onIncreaseShield += RechargeShield;
        
        player.onGameOver += OnGameOver;
        player.onVictory += OnVictory;
        
        shieldChargeText.text = charge.ToString();
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

    private void OnShieldUp(int value)
    {
        charge -= value;
        shieldChargeText.text = charge.ToString();
    }

    private void RechargeShield(int value)
    {
        charge += value;
        shieldChargeText.text = charge.ToString();
    }
}