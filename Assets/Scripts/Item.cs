using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType itemType;

    public int weight;
    public int value;
    public bool isBonusTime;
    public bool isBomb;

    private void Start()
    {
        weight = itemType.weight;
        value = itemType.value;
        isBonusTime = itemType.isBonusTime;
        isBomb = itemType.isBomb;
    }
}