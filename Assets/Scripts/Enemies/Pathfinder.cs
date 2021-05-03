using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, PathTile> grid = new Dictionary<Vector2Int, PathTile>();
    Queue<PathTile> queue = new Queue<PathTile>();
    bool isRunning = true;
    PathTile searchingTile;
    [SerializeField] private List<PathTile> path = new List<PathTile>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left};


    public PathTile StartTile;
    [SerializeField] PathTile EndTile;


    public List<PathTile> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            FindPath();
            SetPath();
        }
        return path;
    }

    private void FindPath()
    {
        queue.Enqueue(StartTile);

        while(queue.Count > 0 && isRunning)
        {
            searchingTile = queue.Dequeue();
            searchingTile.isExplored = true;
            StopIfEndFound();
            ExploreNeighbours();
        }
    }

    private void StopIfEndFound()
    {
        if (searchingTile == EndTile)
        {
            isRunning = false;
        }
    }
    
    private void ExploreNeighbours()
    {
        if(!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int expCoords = searchingTile.GetGridPos() + direction;
            try { QueueNewNeighbours(expCoords); }
            catch {  } // do nothing
        }
    }

    private void QueueNewNeighbours(Vector2Int expCoords)
    {
        PathTile neighbour = grid[expCoords];
        if (neighbour.isExplored || queue.Contains(neighbour) )
        { 
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchingTile;
        }
    }

    private void SetPath()
    {
        SetAsPath(EndTile);
        PathTile prev = EndTile.exploredFrom;
        while(prev != StartTile)
        {
            SetAsPath(prev);
            prev = prev.exploredFrom;
        }
        SetAsPath(StartTile);
        path.Reverse();
    }

    private void SetAsPath(PathTile tile)
    {
        path.Add(tile);
    }

    private void LoadBlocks()
    {
        var tiles = FindObjectsOfType<PathTile>();
        foreach(PathTile t in tiles)
        {
            if (grid.ContainsKey(t.GetGridPos()))
            { Debug.Log("Overlapping block: " + t); }
            else
            { 
                grid.Add(t.GetGridPos(), t);
                //t.SetTileColor(Color.red);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
