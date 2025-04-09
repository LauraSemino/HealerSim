using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public Transform[] eSpawns;
    public Transform[] fSpawns;
    public List<GameObject> enemies;
    public List<GameObject> friends;
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
            foreach (GameObject friend in friends)
            {
                friend.transform.position = fSpawns[friends.IndexOf(friend)].position;
            }
            spawnUnits();
        }
        List<GameObject> deadGuys = new List<GameObject>();
        foreach(GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Health>().health <= 0)
            {
                deadGuys.Add(enemy);
                //enemies.Remove(enemy);
            }
        }
        foreach(GameObject enemy in deadGuys)
        {
            enemies.Remove(enemy);
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
