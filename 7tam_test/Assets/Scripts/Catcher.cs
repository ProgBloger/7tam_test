using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Catcher : MonoBehaviour
{
    [SerializeField] float speed = 300f;
    [SerializeField] float moveStepDelay = 0.5f;
    [SerializeField] float moveStep = 5;
    [SerializeField] Player player;
    [SerializeField] PathResolver pathResolver;
    [SerializeField] Waypoint currentWaypoint;
    private Waypoint destinationWaypoint;
    private Stack<Waypoint> currentPath;
    Vector2 targetPosition;
    private float lerpTime = 0;

    void Start()
    {
        UpdatePath();
        targetPosition = transform.position;
    }

    void Update()
    {
        lerpTime += Time.deltaTime;
        
        if(lerpTime <= moveStepDelay)
        {
            MakeAMove();
        }
        else
        {
            lerpTime = 0;
            DecideThePath();
        }
    }

    private void MakeAMove()
    {
        // Move the pathway
        var lerped = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime*moveStep);
        transform.position = lerped;
    }

    private void DecideThePath()
    {
        var playerWP = player.currentWaypoint;

        if(playerWP != destinationWaypoint)
        {
            UpdatePath();
        }
        else
        {
            UpdateStepPosition();
        }
    }

    private void UpdatePath()
    {
        var playerWP = player.currentWaypoint;
        
        destinationWaypoint = playerWP;
        // Construct new path
        currentPath = pathResolver.GetPath(currentWaypoint, destinationWaypoint);
        
    }

    private void UpdateStepPosition()
    {
        var wp = currentPath.Pop();
        // transform.LookAt(wp.transform);
        
        targetPosition = wp.transform.position;
        currentWaypoint = wp;
    }
}
