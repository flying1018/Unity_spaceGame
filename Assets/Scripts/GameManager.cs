using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState { Playing, GameOver, GameClear }
    private float gameGravity = 30f;
    public float GameGravity { get => gameGravity; }

    static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void GameOver(int input)
    {
        if (input == 1)
        {
            Time.timeScale = 0;
            UIManager.Instance.gameOver.text = "GameOver..";
            UIManager.Instance.retryButton.SetActive(true);

        }
        else if (input == 2)
        {
            Time.timeScale = 0;
            UIManager.Instance.gameOver.text = "Win!";
            UIManager.Instance.retryButton.SetActive(true);
        }
    }
}
