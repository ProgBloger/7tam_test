using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] bool isRunning = true;
    [SerializeField] WaypointGrid grid;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Waypoint searchPoint;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    public void PathFindAlgorythm(Waypoint startPoint, Waypoint endPoint)
    {
        queue.Enqueue(startPoint);
        while(queue.Count > 0 && isRunning == true)
        {
            searchPoint = queue.Dequeue();
            searchPoint.isExplored = true;
            CheckForEndPoint(endPoint);
            ExploreNearPoints();
        }
    }

    private void ExploreNearPoints()
    {
        if(!isRunning)
        {
            return;
        }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int nearPointCoordinates = searchPoint.GetGridPos() + direction;
            
            try
            {
                Waypoint nearPoint = grid[nearPointCoordinates];
                
                AddPointToQueue(nearPoint);
            }
            catch
            {
            }
        }
    }

    private void AddPointToQueue(Waypoint nearPoint)
    {
        if(nearPoint.isExplored || queue.Contains(nearPoint))
        {
            return;
        }

        nearPoint.exploredFrom = searchPoint;
        queue.Enqueue(nearPoint);
    }

    private void CheckForEndPoint(Waypoint endPoint)
    {
        if(searchPoint == endPoint)
        {
            isRunning = false;
        }
    }
}
