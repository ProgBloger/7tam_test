using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGrid : MonoBehaviour
{
    [SerializeField] public  Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] int currentId;
    
    void Awake()
    {
        LoadBlocks();
    }
    
    public Waypoint this[Vector2Int i]
    {
        get { {return grid[i];} }
        set { grid[i] = value; }
    }

    public Waypoint GetNextWaypoint(Waypoint current, Vector2 direction)
    {
        Vector2Int nearPointCoordinates = current.GetGridPos() + Vector2Int.RoundToInt(direction);
        if(grid.ContainsKey(nearPointCoordinates))
        {
            return grid[nearPointCoordinates];
        }

        return null;
    }

    public bool ContainsKey(Vector2Int gridPosition)
    {
        return grid.ContainsKey(gridPosition);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(var wp in waypoints)
        {
            var gridPosition = wp.GetGridPos();
            bool isOverlapping = grid.ContainsKey(gridPosition);
            if(isOverlapping)
            {
                Debug.LogWarning($"Overlapping {wp}");
            }
            else
            {
                grid.Add(gridPosition, wp);
            }
        }
    }
}
