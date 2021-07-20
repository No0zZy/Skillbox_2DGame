using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject menuPanel;

    public void UpdateMoneyText(int money)
    {
        moneyText.text = money.ToString();
    }

    private void Update()
    {
        int minutes = (int)(GameManager.Instance.PlayTime / 60);
        int seconds = (int)(GameManager.Instance.PlayTime % 60);

        timeText.text = $"{minutes:00}:{seconds:00}";
    }

    public void Resume()
    {
        Time.timeScale = 1;
        menuButton.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menuButton.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneLoader.LoadMainMenu();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneLoader.ReloadScene();
    }
}
