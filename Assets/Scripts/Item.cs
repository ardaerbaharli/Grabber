using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int weight;
    public int value;
    public bool isBonusTime;
    public bool isBomb;

    public ItemType itemType;

    // Start is called before the first frame update
    void Start()
    {
        this.value = itemType.value;
        this.weight = itemType.weight;
        this.isBomb = itemType.isBomb;
        this.isBonusTime = itemType.isBonusTime;
    }
}
