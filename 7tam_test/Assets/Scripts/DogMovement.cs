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
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<Player>() != null)
        {
            // TODO: Game over component

            return;
        }
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
