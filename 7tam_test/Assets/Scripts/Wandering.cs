using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float maxDistance;
    public Vector2 Movement {get; private set;}
    Rigidbody2D body;
    Vector2 newPosition;
    Vector2 previousFixedUpdatemovement;

    float GetRandomPoint() => Random.Range(-maxDistance, maxDistance);

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;

        SetNewDestination();
    }
   
    void FixedUpdate()
    {
        var movement = Vector2.Lerp(transform.position,newPosition,Time.deltaTime*speed);

        if(Vector2.Distance(transform.position, newPosition) < 1 || movement == previousFixedUpdatemovement)
        {
            SetNewDestination();
            movement = Vector2.Lerp(transform.position,newPosition,Time.deltaTime*speed);
        }
        
        Movement = movement;
        body.MovePosition(movement);
        previousFixedUpdatemovement = movement;
    }

    public void SetNewDestination()
    {
        newPosition = new Vector2(GetRandomPoint(), GetRandomPoint());
    }
}
