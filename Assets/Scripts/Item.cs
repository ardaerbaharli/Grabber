using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int weight;
    public int value;
    public bool isBonusTime;
    public bool isBomb;
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
            //süre++;
        }
        else if(isBomb)
        {
            //süre--;
        }
        else
        {
            //score++;
        }
    }
}
