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
       for (int i = 0; i < path.Count; i++)
        {
            transform.position = path[i].transform.position + 4 * Vector3.up; 
            if (i < path.Count-1)
            {
                transform.rotation = Quaternion.LookRotation(path[i + 1].transform.position - path[i].transform.position);
            }
            yield return new WaitForSeconds(moveInterval);
        }
    }
    
}
