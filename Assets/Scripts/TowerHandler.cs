using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHandler : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] ParticleSystem bullet;
    [SerializeField] float attackRange = 20f;
    Transform enemyDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
        objectToMove.LookAt(enemyDir);
        Fire();
    }

    private void FindClosestEnemy() 
    {
        var currentEnemies = FindObjectsOfType<EnemyHit>();
        if (currentEnemies.Length > 0)
        {
            Transform cloest = currentEnemies[0].transform;
            for(int i =1; i < currentEnemies.Length; i++)
            {
                var cloestDistance = Vector3.Distance(cloest.position, transform.position);
                var curDistance = Vector3.Distance(currentEnemies[i].transform.position, transform.position);
                if (curDistance < cloestDistance) cloest = currentEnemies[i].transform;
            }
            enemyDir = cloest;
        }
    }

    private void Fire()
    {
        if (enemyDir == null) return;
        float enemyDistance = Vector3.Distance(enemyDir.transform.position, gameObject.transform.position);
        if (enemyDistance <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool enable)
    {
        var emissionModule = bullet.emission;
        emissionModule.enabled = enable;
    }
}
