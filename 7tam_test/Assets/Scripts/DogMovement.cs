using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DogMovement : MonoBehaviour
{
    public bool DogIsChasing { get; private set; }
    private Chasing chasing;
    private Wandering wandering;
    public Transform GetTransform() => this.transform; 
    string currentState;
    Rigidbody2D body;
    Animator anim;
    private const string DogDown = "DogDown";
    private const string DogBack = "DogBack";
    private const string DogForward = "DogForward";
    private const string DogUp = "DogUp";
    private const string DogAngryDown = "DogAngryDown";
    private const string DogAngryBack = "DogAngryBack";
    private const string DogAngryForward = "DogAngryForward";
    private const string DogAngryUp = "DogAngryUp";

    // Start is called before the first frame update
    void Start()
    {
        chasing = GetComponent<Chasing>();
        wandering = GetComponent<Wandering>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        DogIsChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
       var movement = DogIsChasing ? chasing.Movement : wandering.Movement;

        if(Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
        {
            var animationState = DogIsChasing ? DogAngryBack : DogBack;
            ChangeAnimationState(animationState);
            return;
        }

        bool horizontal = Math.Abs(movement.x) > Math.Abs(movement.y);

        if(horizontal)
        {
            Debug.Log(horizontal + "horizontal");
            var animationState = DogIsChasing ? 
                        (movement.x > 0 ? DogAngryForward : DogAngryBack) : 
                        (movement.x > 0 ? DogForward : DogBack);

            ChangeAnimationState(animationState);
        }
        else
        {
            Debug.Log(horizontal + "Vertical");
            var animationState = DogIsChasing ? 
                        (movement.y > 0 ? DogAngryUp : DogAngryDown) : 
                        (movement.y > 0 ? DogUp : DogDown);

            ChangeAnimationState(animationState);
        }
    }

    void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;
        anim.Play(newState);

        currentState = newState;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<FarmerMovement>() != null)
        {
            // Switch state to chasing
            DogIsChasing = true;
            chasing.enabled = DogIsChasing;
            wandering.enabled = !DogIsChasing;

            return;
        }
        // TODO: Add bombComponent
        var farmer = col.gameObject.GetComponent<FarmerMovement>();
        if(farmer != null)
        {
            // Switch state to wandering
            DogIsChasing = false;
            chasing.enabled = DogIsChasing;
            wandering.enabled = !DogIsChasing;

            farmer.SelectTarget();

            // Play dirty animation

            return;
        }

        wandering.SetNewDestination();
    }
}
