using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        
        

        List<GameObject> deadGuys = new List<GameObject>();
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Health>().health <= 0)
            {
                deadGuys.Add(enemy);
                //enemies.Remove(enemy);
            }
        }
        foreach (GameObject enemy in deadGuys)
        {
            enemies.Remove(enemy);
        }

        List<GameObject> deadfren = new List<GameObject>();
        foreach (GameObject friend in friends)
        {
            if (friend.GetComponent<Health>().health <= 0)
            {
                deadfren.Add(friend);
                //enemies.Remove(enemy);
            }
        }
        foreach(GameObject friend in deadfren)
        {
            friends.Remove(friend);
        }

        if (enemies.Count == 0)
        {
            if(roundCount < 10)
            {
                roundCount++;
            }
            
            //respawns allies randomly
            if (roundCount > 0 && roundCount < 3)
            {
                if(friends.Count < 1)
                {
                    friends.Add(Instantiate(unitPrefabs[3]));
                    friends[friends.Count - 1].transform.position = fSpawns[friends.Count - 1].position;
                }
            }
            else if (roundCount >= 4 && roundCount < 5)
            {
                
                if (friends.Count < 2)
                {
                    friends.Add(Instantiate(unitPrefabs[Random.Range(3,5)]));
                    friends[friends.Count - 1].transform.position = fSpawns[friends.Count - 1].position;
                 
                }
            }
            else if (roundCount >= 6)
            {
                if (friends.Count < 3)
                {
                 
                    friends.Add(Instantiate(unitPrefabs[Random.Range(3, 6)]));
                    friends[friends.Count - 1].transform.position = fSpawns[friends.Count - 1].position;
                   
                 
                }
            }
            foreach (GameObject friend in friends)
            {
                friend.transform.position = fSpawns[friends.IndexOf(friend)].position;
            }

            spawnUnits();
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
                enemies[0].GetComponent<Health>().maxHealth = 4;
                enemies[0].transform.position = eSpawns[2].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[1].GetComponent<Health>().maxHealth = 4;
                enemies[1].transform.position = eSpawns[1].position;
                break;
            case 3:              
                //tank added to your team
                friends.Add(Instantiate(unitPrefabs[4]));
                friends[friends.Count-1].transform.position = fSpawns[friends.Count-1].position;

                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[0].GetComponent<Health>().maxHealth = 12;
                enemies[0].transform.position = eSpawns[0].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[1].GetComponent<Health>().maxHealth = 4;
                enemies[1].transform.position = eSpawns[1].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[1].GetComponent<Health>().maxHealth = 4;
                enemies[1].transform.position = eSpawns[2].position;
                break;
            case 4:
                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[0].GetComponent<Health>().maxHealth = 12;
                enemies[0].transform.position = eSpawns[0].position;
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[1].GetComponent<Health>().maxHealth = 5;
                enemies[1].transform.position = eSpawns[1].position;
                
                break;
            case 5:
                //Archer added to your team
                friends.Add(Instantiate(unitPrefabs[5]));
                friends[friends.Count - 1].transform.position = fSpawns[friends.Count-1].position;

                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[0].GetComponent<Health>().maxHealth = 12;
                enemies[0].transform.position = eSpawns[0].position;
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[1].GetComponent<Health>().maxHealth = 6;
                enemies[1].transform.position = eSpawns[1].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[2].GetComponent<Health>().maxHealth = 6;
                enemies[2].transform.position = eSpawns[2].position;
                break;
            case 6:
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[0].GetComponent<Health>().maxHealth = 4;
                enemies[0].transform.position = eSpawns[0].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[1].GetComponent<Health>().maxHealth = 4;
                enemies[1].transform.position = eSpawns[1].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[2].GetComponent<Health>().maxHealth = 4;
                enemies[2].transform.position = eSpawns[2].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[3].GetComponent<Health>().maxHealth = 4;
                enemies[3].transform.position = eSpawns[3].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[4].GetComponent<Health>().maxHealth = 4;
                enemies[4].transform.position = eSpawns[4].position;
                break;
            case 7:
                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[0].GetComponent<Health>().maxHealth = 12;
                enemies[0].transform.position = eSpawns[0].position;
                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[1].GetComponent<Health>().maxHealth = 12;
                enemies[1].transform.position = eSpawns[1].position;
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[2].GetComponent<Health>().maxHealth = 6;
                enemies[2].transform.position = eSpawns[2].position;
                
                break;
            case 8:
                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[0].GetComponent<Health>().maxHealth = 15;
                enemies[0].transform.position = eSpawns[0].position;
                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[0].GetComponent<Health>().maxHealth = 15;
                enemies[0].transform.position = eSpawns[1].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[1].GetComponent<Health>().maxHealth = 8;
                enemies[1].transform.position = eSpawns[2].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[1].GetComponent<Health>().maxHealth = 8;
                enemies[1].transform.position = eSpawns[3].position;
                break;
            case 9:
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[0].GetComponent<Health>().maxHealth = 6;
                enemies[0].transform.position = eSpawns[0].position;
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[1].GetComponent<Health>().maxHealth = 6;
                enemies[1].transform.position = eSpawns[1].position;
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[2].GetComponent<Health>().maxHealth = 6;
                enemies[2].transform.position = eSpawns[2].position;
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[3].GetComponent<Health>().maxHealth = 6;
                enemies[3].transform.position = eSpawns[3].position;
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[4].GetComponent<Health>().maxHealth = 6;
                enemies[4].transform.position = eSpawns[4].position;
                break;
            case 10:
                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[0].GetComponent<Health>().maxHealth = 18;
                enemies[0].transform.position = eSpawns[0].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[1].GetComponent<Health>().maxHealth = 10;
                enemies[1].transform.position = eSpawns[1].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[2].GetComponent<Health>().maxHealth = 10;
                enemies[2].transform.position = eSpawns[2].position;
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[3].GetComponent<Health>().maxHealth = 6;
                enemies[3].transform.position = eSpawns[3].position;
                enemies.Add(Instantiate(unitPrefabs[2]));
                enemies[4].GetComponent<Health>().maxHealth = 6;
                enemies[4].transform.position = eSpawns[4].position;
                break;
        }
    }
}
