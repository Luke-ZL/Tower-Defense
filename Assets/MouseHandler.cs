using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] TowerHandler towerPrefab;
    private bool hasPlacedTower = false;
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
        if (Input.GetMouseButtonDown(0) && !hasPlacedTower)
        {
            hasPlacedTower = true;
            Instantiate(towerPrefab, transform.position + 5 * Vector3.up, Quaternion.identity);
        }
    }
}
