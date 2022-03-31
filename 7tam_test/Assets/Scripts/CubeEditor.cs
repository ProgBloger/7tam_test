using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        var gridPos = waypoint.GetScenePos();
        var newPos = new Vector2(gridPos.x, gridPos.y);
        transform.position = newPos;
    }

    private void UpdateLabel()
    {
        var gridPos = waypoint.GetGridPos();
        
        string labelName = $"{gridPos.x},{gridPos.y}";
        
        TextMesh label = GetComponentInChildren<TextMesh>();
        label.text = labelName;
        
        gameObject.name = labelName;
    }
}
