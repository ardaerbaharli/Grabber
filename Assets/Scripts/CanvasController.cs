using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject timeObject;
    public GameObject scoreObject;
    public GameController gameController;

    private Text timeText;
    private Text scoreText;

    public void Start()
    {
        gameController = FindObjectOfType<GameController>();
        timeText = timeObject.GetComponentInChildren<Text>();
        scoreText = scoreObject.GetComponentInChildren<Text>();
    }

    public void Update()
    {
        if (gameController.isPlaying)
        {
            int mins = Mathf.FloorToInt(gameController.time / 60);
            int seconds = Mathf.FloorToInt(gameController.time - mins * 60);

            timeText.text = $"{mins}:{seconds}";
            scoreText.text = gameController.score.ToString();
        }

    }
}
