using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] int hp = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem goalParticle;
    [SerializeField] AudioClip getHit;
    [SerializeField] AudioClip death;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        hp--;
        if (hp <= 0)
        {
            FindObjectOfType<ScoreHandler>().UpdateScore(1);
            DestroyEnemy(true);
        }
        else
        {
            audioSource.PlayOneShot(getHit);
            hitParticle.Play();
        }
        //print(hp);
    }

    public void DestroyEnemy(bool isKilled)
    {
        ParticleSystem dp;
        if (isKilled)
        {
            AudioSource.PlayClipAtPoint(death, Camera.main.transform.position);
            dp = Instantiate(deathParticle, transform.position, Quaternion.identity);
        } else
        {
            dp = Instantiate(goalParticle, transform.position, Quaternion.identity);
        }
        dp.Play();
        Destroy(dp.gameObject, dp.main.duration);
        Destroy(gameObject);
    }
}
