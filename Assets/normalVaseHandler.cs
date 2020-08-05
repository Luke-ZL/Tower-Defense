using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(normalGridCube))]
public class normalVaseHandler : MonoBehaviour
{
    Vector3 pos;
    normalGridCube normalGridCube;
    // Start is called before the first frame update
    private void Awake()
    {
        normalGridCube = GetComponent<normalGridCube>();
    }

    // Update is called once per frame
    void Update()
    {
        int gridSize = normalGridCube.getGridSize();
        //get grid pos
        pos.x = normalGridCube.getGridPos().x * gridSize;
        pos.z = normalGridCube.getGridPos().y * gridSize;
        transform.position = new Vector3(pos.x, 0f, pos.z);
    }
}
