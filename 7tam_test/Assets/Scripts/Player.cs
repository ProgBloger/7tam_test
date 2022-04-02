using System.Collections;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    public float speed = 4.5f;
    private Rigidbody2D body;
    private BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;

        body.velocity = new Vector2(deltaX, deltaY);

        // anim.SetFloat("speed", Mathf.Abs(deltaX));
    }
}
