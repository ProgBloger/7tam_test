using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    int totalItems;
    int collectedItems = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalItems = GameObject.FindObjectsOfType<Item>().Length;
    }
    
    public void ItemCollected()
    {
        collectedItems++;
        if(collectedItems == totalItems)
        {
            // TODO: Win screen
            Debug.Log($"You won!");
        }
    }
}
