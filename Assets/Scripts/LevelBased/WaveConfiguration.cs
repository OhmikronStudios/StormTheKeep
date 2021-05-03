using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfiguration")]
public class WaveConfiguration : ScriptableObject
{
    [SerializeField] Enemy[] enemyPrefabs;


    public Enemy[] GetEnemyList()
    {
        return enemyPrefabs;
    }






}
