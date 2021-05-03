using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TowerSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Tower_SO tower;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text costText;
    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = tower.towerName;
        costText.text = tower.buildCost.ToString();
        lm = FindObjectOfType<LevelManager>();
    }

    public void OnPointerExit(PointerEventData data)
    {
        lm.overUI = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        lm.overUI = true;
    }

    public void ChooseTower()
    {
        FindObjectOfType<LevelManager>().currentTower = tower;
    }    
}
