using System.Collections;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };


    public float speed = 4.5f;
    public Waypoint waypoint;

    public WaypointGrid grid;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // Current block position
        // Next block position
            // Get direction from player input
        var direction = GetDirection();
            // Get next block from WaypointGrid
        var nextWP = grid.GetNextWaypoint(waypoint, direction);
        
        if(nextWP != null && waypoint != nextWP)
        {
            // TODO: Lerp movement
            transform.position = nextWP.transform.position;
            waypoint = nextWP;
        }
        // Play animation
    }

    private Vector2 GetDirection()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaY = Input.GetAxis("Vertical");
        TurnToInt(ref deltaX);
        TurnToInt(ref deltaY);

        return new Vector2(deltaX, deltaY);
    }

    void TurnToInt(ref float input)
    {
        if(input > 0)
        {
            
            try
            {
                input = (float)Math.Ceiling(input);
            }
            catch
            {
                Debug.Log($"Unexpected value cast  {Math.Ceiling(input)} to float");
            }
        }
        
        if(input < 0)
        {
            try
            {
                input = (float)Math.Floor(input);
            }
            catch
            {
                Debug.Log($"Unexpected value cast  {Math.Ceiling(input)} to float");
            }
        }
    }
}
