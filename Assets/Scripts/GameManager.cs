using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Play,
    Pause,
    Cutscene
}

[RequireComponent(typeof(GameUI))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private static int moneyOnLevelStart;
    private static float timeOnLevelStart;
    private static int enemyKilledOnLevelStart;
    public int Money { get; private set; }
    public float PlayTime { get; private set; }
    public int EnemyKilled { get; private set; }
    public GameState State { get; private set; }
    private GameUI gameUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        gameUI = GetComponent<GameUI>();

        Money = moneyOnLevelStart;
        EnemyKilled = enemyKilledOnLevelStart;
        PlayTime = timeOnLevelStart;
    }

    private void Start()
    {
        gameUI.UpdateMoneyText(Money);
    }

    private void Update()
    {
        PlayTime += Time.deltaTime;
    }

    public void AddScore(int points)
    {
        Money += points;
        gameUI.UpdateMoneyText(Money);
    }

    public void OnEnemyKilled()
    {
        EnemyKilled += 1;
    }

    public void SwitchState(GameState state)
    {
        State = state;
    }

    public void OnNextLevelLoad()
    {
        moneyOnLevelStart = Money;
        timeOnLevelStart = PlayTime;
        enemyKilledOnLevelStart = EnemyKilled;
    }
}