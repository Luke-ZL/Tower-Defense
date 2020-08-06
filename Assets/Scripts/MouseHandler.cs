using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] TowerHandler towerPrefab;
    public bool hasPlacedTower = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hasPlacedTower)
            {
                FindObjectOfType<TowerFactory>().removeTower(this);
            } else
            {
                FindObjectOfType<TowerFactory>().addTower(this);
            }

        }
    }
}
