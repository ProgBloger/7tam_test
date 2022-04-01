using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 5;
    public bool isPlacable = true;
    public bool isExplored = false;
    public Waypoint exploredFrom;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetScenePos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize, 
            Mathf.RoundToInt(transform.position.y / gridSize) * gridSize);
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize), 
            Mathf.RoundToInt(transform.position.y / gridSize));
    }
}
