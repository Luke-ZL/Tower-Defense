using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip hurt;
    // Start is called before the first frame update

    private void Start()
    {
        healthText.text = "HEALTH: " + health.ToString();
    }

    public void onCollideBase(int damage)
    {
        GetComponent<AudioSource>().PlayOneShot(hurt);
        health -= damage;
        healthText.text = "HEALTH: " + health.ToString();
    }
}
