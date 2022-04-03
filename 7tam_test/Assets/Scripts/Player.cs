using System.Collections;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    private Animator anim;
    public float speed = 4.5f;
    private Rigidbody2D body;
    private BoxCollider2D box;
    private string currentState;
    private const string PigForward = "PigForward";
    private const string PigAnimationUp = "PigAnimationUp";
    private const string PigAnimationDown = "PigAnimationDown";
    private const string PigBackward = "PigBackward";

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

        if(Mathf.Approximately(deltaX, 0) && Mathf.Approximately(deltaY, 0))
        {
            ChangeAnimationState(PigForward);
            return;
        }

        bool horizontal = Math.Abs(deltaX) > Math.Abs(deltaY);

        if(horizontal)
        {
            bool forward = deltaX > 0;
            if(forward)
            {
                ChangeAnimationState(PigForward);
            }
            else
            {
                ChangeAnimationState(PigBackward);
            }
        }
        else
        {
            bool up = deltaY > 0;
            if(up)
            {
                ChangeAnimationState(PigAnimationUp);
            }
            else
            {
                ChangeAnimationState(PigAnimationDown);
            }
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
        bool caughtByFarmer = col.gameObject.GetComponent<FarmerMovement>() != null;
        bool caughtByDog = col.gameObject.GetComponent<DogMovement>() != null;

        if(caughtByFarmer || caughtByDog)
        {
            sceneLoader.LoadLoseScene();
        }
    }
}