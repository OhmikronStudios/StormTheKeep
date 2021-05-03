using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : Tile
{ 
    public bool isPlaceable = true;
    //[SerializeField] Tower towerPrefab;
    
    

    public void BuildTower(Tower_SO tower)
    {

        if (lm.GetFunds() >= tower.buildCost)
        {
            lm.DeductFunds(tower.buildCost);
            Instantiate(tower.prefab, transform.position, Quaternion.identity, gameObject.transform);
            isPlaceable = false;
        }
    }

    
}
