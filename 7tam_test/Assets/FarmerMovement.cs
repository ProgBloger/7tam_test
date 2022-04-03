using System.Linq;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FarmerMovement : MonoBehaviour
{
    List<DogMovement> dogs;
    [SerializeField] Transform player;
    DogMovement currentDog;
    Chasing chasing;
    private const string FarmerDown = "FarmerDown";
    private const string FarmerUp = "FarmerUp";
    private const string FarmerBack = "FarmerBack";
    private const string FarmerForward = "FarmerForward";
    private string currentState;
    Animator anim;
    bool musicSwitched = false;
    AudioSwitch audioSwitch;
    Vector2 previousFixedUpdatemovement;

    // Start is called before the first frame update
    void Start()
    {
        var dogArray = GameObject.FindObjectsOfType<DogMovement>();
        dogs = new List<DogMovement>(dogArray);
        chasing = GetComponent<Chasing>();
        anim = GetComponent<Animator>();
        audioSwitch = GetComponent<AudioSwitch>();

        // Debug.Log("Dogs found:" + dogs.Count);
        SelectTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDog.DogIsChasing)
        {
            if(!musicSwitched)
            {
                audioSwitch.Switch();
                musicSwitched = true;
            }
            SelectTarget();
        }

        var movement = chasing.Movement;

        if(movement == previousFixedUpdatemovement)
        {
            SelectTarget();
        }

        previousFixedUpdatemovement = movement;

        if(Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
        {
            ChangeAnimationState(FarmerBack);
            return;
        }

        bool horizontal = Math.Abs(movement.x) > Math.Abs(movement.y);

        if(horizontal)
        {
            var animationState = movement.x > 0 ? FarmerForward : FarmerBack;

            ChangeAnimationState(animationState);
        }
        else
        {
            var animationState = movement.y > 0 ? FarmerUp : FarmerDown;

            ChangeAnimationState(animationState);
        }
    }

    public void SelectTarget()
    {
        DogMovement closestDog = GetClosestDog();

        if (closestDog != null)
        {
            chasing.target = closestDog.GetTransform();
            currentDog = closestDog;
        }
        else
        {
            chasing.target = player;
        }
    }

    private DogMovement GetClosestDog()
    {
        var dogDic = dogs.Where(d => !d.DogIsChasing).Select(d => new { d = d, distance = d.transform.position - transform.position });
        DogMovement closestDog = null;
        float closestMagnitude = 0.0f;
        foreach (var dog in dogs.Where(d => !d.DogIsChasing))
        {
            var thisDogMagnitude = (dog.transform.position - transform.position).sqrMagnitude;
            if (closestDog == null || closestMagnitude > thisDogMagnitude)
            {
                closestDog = dog;
                closestMagnitude = thisDogMagnitude;
            }
        }

        return closestDog;
    }

    void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;
        anim.Play(newState);

        currentState = newState;
    }
}
