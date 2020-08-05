using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHandler : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] Transform enemyDir;
    [SerializeField] ParticleSystem bullet;
    [SerializeField] float attackRange = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectToMove.LookAt(enemyDir);
        Fire();
    }

    private void Fire()
    {
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
