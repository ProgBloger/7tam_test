using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathResolver : MonoBehaviour
{
    [SerializeField] PathFinder pathFinder;
    [SerializeField] public List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath(Waypoint startPoint, Waypoint endPoint)
    {
        if(path.Count == 0)
        {
            pathFinder.PathFindAlgorythm(startPoint, endPoint);
            CreatePath(startPoint, endPoint);
        }

        return path;
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

        path.Reverse();
    }

    private void AddPointToPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlacable = false;
    }
}
