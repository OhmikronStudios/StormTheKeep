using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower")]
public class Tower_SO : ScriptableObject
{
    public string towerName;
    public int buildCost;
    public Tower prefab;
}
