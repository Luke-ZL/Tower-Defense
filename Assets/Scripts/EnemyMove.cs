using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    List<GridCube> path;
    [SerializeField] float moveInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        MapHandler mapHandler = FindObjectOfType<MapHandler>();
        path = mapHandler.getPath();
        StartCoroutine(MoveAlongPath());
    }

    IEnumerator MoveAlongPath()
    {
       foreach(GridCube gc in path)
        {
            transform.position = gc.transform.position + 4 * Vector3.up;
            yield return new WaitForSeconds(moveInterval);
        }
    }
    
}
