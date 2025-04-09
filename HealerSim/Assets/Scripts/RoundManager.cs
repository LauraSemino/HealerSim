using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public Transform[] eSpawns;
    public List<GameObject> enemies;
    public GameObject[] unitPrefabs;
    public int roundCount;
    public TextMeshProUGUI roundTXT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundTXT.text = ("Round: " + roundCount);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spawnUnits();
        }
        if(enemies.Count == 0)
        {
            roundCount++;
            spawnUnits();
        }

        foreach(GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Health>().health <= 0)
            {
                enemies.RemoveAt(enemies.IndexOf(enemy));
            }
        }


    }

    void spawnUnits()
    {
        switch (roundCount)
        {
            case 1:
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[0].GetComponent<Health>().maxHealth = 8;
                enemies[0].transform.position = eSpawns[0].position;
                
                break;
            case 2:
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[0].GetComponent<Health>().maxHealth = 8;
                enemies[0].transform.position = eSpawns[0].position;
                break;
        }
    }
}
