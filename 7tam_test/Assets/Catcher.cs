using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Catcher : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float moveStep = 5;
    [SerializeField] Player player;
    [SerializeField] PathResolver pathResolver;
    [SerializeField] Waypoint currentWaypoint;
    private Waypoint destinationWaypoint;
    private List<Waypoint> currentPath;
    private bool pathWasChanged;
    Vector2 targetPosition;

    void Start()
    {
        UpdatePath();
        // StartCoroutine(EnemyMove());
    }

    void Update()
    {
        // Move the pathway
        // transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*moveStep);
    }

    private void UpdatePath()
    {
        // Get Player's Waypoint
        var playerWP = player.waypoint;
        bool timeElapsed = true;
        // If the waypoint has changed and time elapsed
        // TODO: check that comparison works
        // TODO: add coroutine to wait elapsed time
        if(playerWP != destinationWaypoint && timeElapsed)
        {
            destinationWaypoint = playerWP;
            // Construct new path
            currentPath = pathResolver.GetPath(currentWaypoint, destinationWaypoint);

            pathWasChanged = true;
        }
        // Suspend Playr position checking
    }

    IEnumerator EnemyMove()
    {
        for(int i = 0; i < currentPath.Count; i++)
        {
            if(pathWasChanged)
            {
                // Reset path loop
                // Start from the first element
                i = 0;
                pathWasChanged = false;
            }

            var block = currentPath[0];
            transform.LookAt(block.transform);

            targetPosition = block.transform.position;
            currentWaypoint = block;
            
            yield return new WaitForSeconds(speed);
        }
    }
}
