using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    int totalItems;
    int collectedItems = 0;
    [SerializeField] SceneLoader sceneLoader;

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
            sceneLoader.LoadWinScene();
        }
    }
}
