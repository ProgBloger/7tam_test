using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float moveSpeed = 5f;
    float maxDistance;
    Rigidbody2D body;
    Vector2 wayPoint;

    float GetRandomPoint() => Random.Range(-maxDistance, maxDistance);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;

        SetNewDestination();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = wayPoint - (Vector2)transform.position;
        body.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

        if(Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(GetRandomPoint(), GetRandomPoint());
    }
}
