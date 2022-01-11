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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isBonusTime)
        {
            gameController.BonusTime(5);
        }
        else if(isBomb)
        {
            gameController.MinusTime(-5);
        }
        else
        {
            gameController.BonusScore(value);
        }
    }
}
