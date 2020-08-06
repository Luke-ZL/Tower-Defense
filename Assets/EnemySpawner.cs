using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 4f;
    [SerializeField] EnemyMove enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.LookRotation(Vector3.right));
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
