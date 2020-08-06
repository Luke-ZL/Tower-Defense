using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 4f;
    [SerializeField] EnemyMove enemy;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            print(transform.position);
            var newEnemy = Instantiate(enemy, transform.position, Quaternion.LookRotation(Vector3.right));
            newEnemy.transform.parent = parent;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
