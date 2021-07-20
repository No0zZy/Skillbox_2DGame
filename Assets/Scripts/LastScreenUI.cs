using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastScreenUI : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text killedEnemiesText;


    private void Start()
    {
        coinsText.text = GameManager.Instance.Money.ToString();
        int minutes = (int)(GameManager.Instance.PlayTime / 60);
        int seconds = (int)(GameManager.Instance.PlayTime % 60);

        timeText.text = $"{minutes:00}:{seconds:00}";
        killedEnemiesText.text = GameManager.Instance.EnemyKilled.ToString();
    }
}
