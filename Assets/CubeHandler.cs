using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;


[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(GridCube))]
public class CubeHandler : MonoBehaviour
{

    TextMesh textMesh;
    Vector3 pos;
    GridCube gridCube;

    private void Awake()
    {
        gridCube = GetComponent<GridCube>();
    }



    // Update is called once per frame
    void Update()
    {
        int gridSize = gridCube.getGridSize();
        //get grid pos
        pos.x = gridCube.getGridPos().x * gridSize;
        pos.z = gridCube.getGridPos().y * gridSize;
        transform.position = new Vector3(pos.x, 0f, pos.z);
        //update label
        textMesh = GetComponentInChildren<TextMesh>();
        string coord = pos.x / gridSize + "," + pos.z / gridSize;
        textMesh.text = coord;
        gameObject.name = coord;
    }
}
