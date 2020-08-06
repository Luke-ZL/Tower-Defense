using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] TowerHandler towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform parent;
    [SerializeField] Text towerText;
    private int towerCount = 0;
    Dictionary<Vector3, TowerHandler> towerMap = new Dictionary<Vector3, TowerHandler>();

    private void Start()
    {
        towerText.text = "TOWERS: " + (towerLimit - towerCount);
    }

    public void addTower(MouseHandler mouseHandler)
    {
        if (towerCount < towerLimit)
        {
            towerCount++;
            towerText.text = "TOWERS: " + (towerLimit - towerCount);
            mouseHandler.hasPlacedTower = true;
            var newTower = Instantiate(towerPrefab, mouseHandler.transform.position + 5 * Vector3.up, Quaternion.identity);
            newTower.transform.parent = parent;
            towerMap[mouseHandler.transform.position] = newTower;
        }
    }

    public void removeTower(MouseHandler mouseHandler)
    {
        towerCount--;
        towerText.text = "TOWERS: " + (towerLimit - towerCount);
        Destroy(towerMap[mouseHandler.transform.position].gameObject);
        towerMap.Remove(mouseHandler.transform.position);
        mouseHandler.hasPlacedTower = false;
    }
}
