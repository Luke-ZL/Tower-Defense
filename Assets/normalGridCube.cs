using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalGridCube : MonoBehaviour
{
    const int gridSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getGridSize()
    {
        return gridSize;
    }

    public Vector2Int getGridPos()
    {
        // we don't have to recompute the pos everytime throughout the game
        /*
        if (!initializedPos)
        {
            gridPos = new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize), Mathf.RoundToInt(transform.position.z / gridSize));
            initializedPos = true;
        }
        return gridPos;*/
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize), Mathf.RoundToInt(transform.position.z / gridSize));
    }
}
