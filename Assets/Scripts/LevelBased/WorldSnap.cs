using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class WorldSnap : MonoBehaviour
{
     
    Vector3 snapPos;
    Tile tile;
    [SerializeField] bool showCoords = true;

    private void Awake()
    {
        tile = GetComponent<Tile>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = tile.GetGridSize();
        transform.position = new Vector3(tile.GetGridPos().x * gridSize, 0f, tile.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh tm;
        if (tm = GetComponentInChildren<TextMesh>())
        {
            string coord = tile.GetGridPos().x + "," + tile.GetGridPos().y;
            if (showCoords)
                tm.text = coord;
            else
                tm.text = "";
            //gameObject.name = "Cube: " + coord;
        }
    }
}
