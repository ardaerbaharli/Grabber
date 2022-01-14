using UnityEngine;

public class Item : MonoBehaviour
{
    public int weight;
    public int value;
    public bool isBonusTime;
    public bool isBomb;

    [SerializeField] private GameController gameController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBonusTime)
        {
            gameController.BonusTime(5);
        }
        else if (isBomb)
        {
            gameController.MinusTime(-5);
        }
        else
        {
            gameController.IncreaseScore(value);
        }
    }
}