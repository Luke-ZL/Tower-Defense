using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 4f;
    [SerializeField] EnemyMove enemy;
    [SerializeField] Transform parent;
    [SerializeField] bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            enemy.isLeft = isLeft;
            var newEnemy = Instantiate(enemy, transform.position, Quaternion.LookRotation(Vector3.right));
            newEnemy.transform.parent = parent;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
