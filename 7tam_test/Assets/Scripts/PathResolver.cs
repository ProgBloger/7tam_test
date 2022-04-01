using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathResolver : MonoBehaviour
{
    [SerializeField] PathFinder pathFinder;
    [SerializeField] public List<Waypoint> path = new List<Waypoint>();

    public Stack<Waypoint> GetPath(Waypoint startPoint, Waypoint endPoint)
    {
        Debug.Log($"startPoint{startPoint.GetGridPos()}");
        Debug.Log($"endPoint{endPoint.GetGridPos()}");
        
        pathFinder.PathFindAlgorythm(startPoint, endPoint);
        CreatePath(startPoint, endPoint);
        
        foreach(var item in path)
        {
            Debug.Log($"item {item.GetGridPos()}");
        }

        return new Stack<Waypoint> (path);
    }

    private void CreatePath(Waypoint startPoint, Waypoint endPoint)
    {
        AddPointToPath(endPoint);
        
        Waypoint prevPoint = endPoint.exploredFrom;
        while(prevPoint != startPoint){
            AddPointToPath(prevPoint);
            prevPoint = prevPoint.exploredFrom;
        }

        AddPointToPath(startPoint);
        // Commited cuz swithced to stack
        // path.Reverse();
    }

    private void AddPointToPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlacable = false;
    }
}
