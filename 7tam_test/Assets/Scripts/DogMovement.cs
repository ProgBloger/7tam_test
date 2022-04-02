using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public bool DogIsChasing { get; private set; }

    private Chasing chasing;
    private Wandering wandering;
    public Transform GetTransform() => this.transform; 

    // Start is called before the first frame update
    void Start()
    {
        chasing = GetComponent<Chasing>();
        wandering = GetComponent<Wandering>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collider2D other)
    {
        Debug.Log("Dog OnTriggerEnter");
        if(other.GetComponent<Player>() != null)
        {
            // TODO: Game over component
        }
        if(other.GetComponent<FarmerMovement>() != null)
        {
            // Switch state to chasing
            DogIsChasing = true;
            chasing.enabled = DogIsChasing;
            wandering.enabled = !DogIsChasing;
        }
        // TODO: Add bombComponent
        var farmer = other.GetComponent<FarmerMovement>();
        if(farmer != null)
        {
            // Switch state to wandering
            DogIsChasing = false;
            chasing.enabled = DogIsChasing;
            wandering.enabled = !DogIsChasing;

            farmer.SelectTarget();

            // Play dirty animation
        }
    }
}
