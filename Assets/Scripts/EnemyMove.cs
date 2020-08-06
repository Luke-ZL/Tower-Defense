using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    List<GridCube> path;
    [SerializeField] float moveInterval = 1f;
    public bool isLeft;
    int checkPoint = 0;
    const float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        MapHandler mapHandler = FindObjectOfType<MapHandler>();
        path = mapHandler.getPath(isLeft);
        transform.position = path[0].transform.position + 4 * Vector3.up;
        transform.rotation = Quaternion.LookRotation(path[1].transform.position - path[0].transform.position);
        //StartCoroutine(MoveAlongPath());
    }

    private void Update()
    {
        if (checkPoint >= path.Count - 1)
        {
            FindObjectOfType<HealthHandler>().onCollideBase(1);
            GetComponent<EnemyHit>().DestroyEnemy(false);
        } else
        {
            //Vector3 dir = path[checkPoint + 1].transform.position - path[checkPoint].transform.position;
            transform.Translate(Time.deltaTime * (speed / moveInterval)* Vector3.forward * path[0].getGridSize());
            if (Vector3.Distance(transform.position, path[checkPoint].transform.position) >= Vector3.Distance(path[checkPoint + 1].transform.position, path[checkPoint].transform.position))
            {
                checkPoint++;
                if (checkPoint == path.Count - 1) return;
                transform.rotation = Quaternion.LookRotation(path[checkPoint+1].transform.position - path[checkPoint].transform.position);
                transform.position = path[checkPoint].transform.position + 4 * Vector3.up;
            }
        }
    }

    /*
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
        FindObjectOfType<HealthHandler>().onCollideBase(1);
        GetComponent<EnemyHit>().DestroyEnemy(false);
    }
    */
}
