using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private EventManager eventManager;
    [SerializeField] private TMP_Text shieldChargeText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject panelGameOver;
    public bool isShieldActive;
    private float timer = 0;
    private int score = 0;
    private int charge = 2;
    
    
    private static GameManager _instance;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance= this;
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1;
    }

    private void Start()
    {
        victoryText.SetActive(false);
        
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
        if (!isShieldActive)
        {
            panelGameOver.SetActive(true);
            Time.timeScale = 0;
        }
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
        isShieldActive = true;
    }

    private void RechargeShield(int value)
    {
        charge += value;
        shieldChargeText.text = charge.ToString();
    }

    public void onQuit()
    {
        Application.Quit();
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("Main");
    }
}