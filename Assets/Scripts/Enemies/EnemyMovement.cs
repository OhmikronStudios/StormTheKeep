using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pf = FindObjectOfType<Pathfinder>();
        var path = pf.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<PathTile> path)
    {
        foreach(PathTile tile in path)
        {
            transform.position = tile.transform.position;
            yield return new WaitForSeconds(0.25f);
        }
    }

}
