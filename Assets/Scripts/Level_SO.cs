using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Level")]
public class Level_SO : ScriptableObject
{
    public string levelname;
    public Sprite mapImage;
    public bool isUnlocked;
    public int levelNum;
}
