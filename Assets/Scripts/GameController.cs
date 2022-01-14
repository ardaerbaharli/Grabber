using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameUIInteractions gameUIInteractions;

    public float time;
    public int score;

    public bool isGameStarted;
    public bool isPlaying;
    public bool isGameEnded;

    private const int totalGameTime = 120;

    public void Awake()
    {
        time = totalGameTime;
        score = 0;
    }

    private void Start()
    {
        StartPlaying();
    }

    public void Update()
    {
        if (isPlaying)
        {
            if (time > 0)
                time -= Time.deltaTime;
            else
                GameOver();
        }
    }

    public void StartPlaying()
    {
        isGameStarted = true;
        isPlaying = true;
    }

    public void GameOver()
    {
        isPlaying = false;
        isGameEnded = true;
        PlayerPrefs.SetInt("Score", score);
        gameUIInteractions.ShowGameOverPanel();
    }

    public void BonusTime(float amount)
    {
        time += amount;
    }

    public void MinusTime(float amount)
    {
        time -= amount;
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }
}