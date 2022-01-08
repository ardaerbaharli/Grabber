using UnityEngine;

public class GameController : MonoBehaviour
{
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

    public void Update()
    {
        if (isPlaying)
        {
            time -= Time.deltaTime;

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
    }

    public void BonusTime(float amount)
    {
        time += amount;
    }

    public void MinusTime(float amount)
    {
        time -= amount;
    }
}
