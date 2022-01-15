using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemType : ScriptableObject
{
    public int weight;
    public int value;
    public bool isBonusTime;
    public bool isBomb;
}
