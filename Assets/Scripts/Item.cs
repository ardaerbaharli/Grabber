using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int weight;
    public int value;
    public bool isBonusTime;
    public bool isBomb;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isBonusTime)
        {
            gameController.time += 5;
        }
        else if(isBomb)
        {
            gameController.time -= 5;
        }
        else
        {
            gameController.score += value;
        }
    }
}
