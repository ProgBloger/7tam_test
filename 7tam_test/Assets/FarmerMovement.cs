using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMovement : MonoBehaviour
{
    List<DogMovement> dogs;
    [SerializeField] Transform player;
    DogMovement currentDog;
    Chasing chasing;

    // Start is called before the first frame update
    void Start()
    {
        var dogArray = GameObject.FindObjectsOfType<DogMovement>();
        dogs = new List<DogMovement>(dogArray);
        chasing = GetComponent<Chasing>();

        SelectTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDog.DogIsChasing)
        {
            SelectTarget();
        }
    }

    public void SelectTarget()
    {
        var nextDog = dogs.FirstOrDefault(d => !d.DogIsChasing);
        if(nextDog != null)
        {
            chasing.target = nextDog.GetTransform();
        }
        else
        {
            chasing.target = player;
        }
    }
}
