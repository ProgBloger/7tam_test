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


    public float moveStepDelay = 0.5f;
    public float moveStepSpeed = 10;
    public Waypoint currentWaypoint;
    public Waypoint nextWP;
    public WaypointGrid grid;
    private float lerpTime = 0;


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // 
        if(nextWP != null && currentWaypoint != nextWP)
        {
            lerpTime += Time.deltaTime;

            MakeAMove();

            // Destination position is reached
            if(lerpTime >= moveStepDelay)
            {
                // Debug.Log($"next to current set");
                currentWaypoint = nextWP;
            }
        }
        else
        {
            var direction = GetDirection();
            // Debug.Log($"Direction {direction}");
            // Debug.Log($"currentWaypoint {currentWaypoint.GetGridPos()}");
            nextWP = grid.GetNextWaypoint(currentWaypoint, direction);
            // Debug.Log($"Next wp is null {nextWP == null}");
            lerpTime = 0;
        }
        // Play animation
    }

    private void MakeAMove()
    {
        var playerPosition = transform.position;
            var nextWPPosition = nextWP.transform.position;

            var lerped = Vector2.Lerp(
                playerPosition, 
                nextWPPosition, 
                Time.deltaTime*moveStepSpeed);
            
            transform.position = lerped;
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
