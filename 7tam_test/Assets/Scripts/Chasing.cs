using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f;
    private Rigidbody2D body;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;
        body.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
