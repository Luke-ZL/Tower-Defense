using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] int hp = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        hp--;
        if (hp <= 0)
        {
            var dp = Instantiate(deathParticle, transform.position, Quaternion.identity);
            dp.Play();
            Destroy(gameObject);
        } else
        {
            hitParticle.Play();
        }
        //print(hp);
    }
}
