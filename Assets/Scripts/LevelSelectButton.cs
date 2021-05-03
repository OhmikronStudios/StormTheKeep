using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField] Level_SO level;
    [SerializeField] TMP_Text levelNum;
    [SerializeField] Sprite lockedIcon;


    // Start is called before the first frame update
    void Start()
    {
        if(!level.isUnlocked)
        {
            GetComponent<Image>().sprite = lockedIcon;
            levelNum.text = "";
        }
        else
        {
            levelNum.text = level.levelNum.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel()
    {
        if (level.isUnlocked)
        {
            MenuUI m = FindObjectOfType<MenuUI>();
            m.mapImage.sprite = level.mapImage;
            m.levelName = level.levelname;
        }
    }
}
