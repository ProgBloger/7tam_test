using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemController itemController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        if(other.GetComponent<Player>() != null)
        {
            Debug.Log("Item Triggered");
            itemController.ItemCollected();
            Destroy(this.gameObject);
        }
    }
}
