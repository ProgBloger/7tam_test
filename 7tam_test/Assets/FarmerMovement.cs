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

        // Debug.Log("Dogs found:" + dogs.Count);
        SelectTarget();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("currentDog.DogIsChasing" + currentDog.DogIsChasing);
        if(currentDog.DogIsChasing)
        {
            SelectTarget();
        }
    }

    public void SelectTarget()
    {
        Debug.Log("SelectTarget");
        var nextDog = dogs.FirstOrDefault(d => !d.DogIsChasing);
        Debug.Log("Next dog is null:" + nextDog == null);
        if(nextDog != null)
        {
            Debug.Log("Next dog transform" + nextDog.GetTransform());
            chasing.target = nextDog.GetTransform();
            currentDog = nextDog;
        }
        else
        {
            
            Debug.Log("Chasing Player");
            chasing.target = player;
        }
    }
}
