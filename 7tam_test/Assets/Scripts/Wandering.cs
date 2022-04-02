using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float maxDistance;
    Rigidbody2D body;
    Vector2 newPosition;
    Vector2 previousFixedUpdatemovement;

    float GetRandomPoint() => Random.Range(-maxDistance, maxDistance);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;

        SetNewDestination();
    }

    // void Update()
    // {
    //     transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
    // }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     var lerp = Vector2.Lerp(newPosition, (Vector2)transform.position, moveSpeed * Time.deltaTime);

    //     Vector2 direction = newPosition - (Vector2)transform.position;
    //     body.MovePosition(lerp);

    //     var movePisition = (Vector2)transform.position + (direction * moveSpeed * Time.deltaTime);
    //     Debug.Log(lerp);
    //     if(Vector2.Distance(transform.position, newPosition) < range)
    //     {
    //         SetNewDestination();
    //     }
    // }
   
    void FixedUpdate()
    {
        var movement = Vector2.Lerp(transform.position,newPosition,Time.deltaTime*speed);

        if(Vector2.Distance(transform.position, newPosition) < 1 || movement == previousFixedUpdatemovement)
            SetNewDestination();
 
        body.MovePosition(movement);
        previousFixedUpdatemovement = movement;
    }

    public void SetNewDestination()
    {
        newPosition = new Vector2(GetRandomPoint(), GetRandomPoint());
    }
}
