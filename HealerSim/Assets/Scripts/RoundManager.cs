using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        /** if(Input.GetKeyDown(KeyCode.Space))
         {
             spawnUnits();
         } 
         */
        if (roundCount >= 11)
        {
         //  SceneManager.LoadScene("Victory", LoadSceneMode.Single);
         //  SceneManager.UnloadSceneAsync("Main");
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
            if (roundCount <= 10)
            {
                roundCount++;
            }
            if (roundCount > 1)
            { 
                //not sure if i should keep this tbh
                //FMODUnity.RuntimeManager.PlayOneShot("{6c05fb38-5fb9-4fb9-a8d4-05f5964f260c}");
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
            else if (roundCount >= 6 && roundCount <= 10)
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
                FMODUnity.RuntimeManager.PlayOneShot("{08c839d2-341e-4072-a24c-57d4fb50d786}");
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[0].GetComponent<Health>().maxHealth = 8;
                enemies[0].transform.position = eSpawns[0].position;
                
                break;
            case 2:
                FMODUnity.RuntimeManager.PlayOneShot("{90c63579-19d1-4f3c-9de0-a3c429ae74d8}");
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

                FMODUnity.RuntimeManager.PlayOneShot("{c02c74fe-fa94-4c3f-b429-618c75759d10}");
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
                FMODUnity.RuntimeManager.PlayOneShot("{4487d470-e00f-4e3e-a865-152fa76c6845}");
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

                FMODUnity.RuntimeManager.PlayOneShot("{4efd7aa8-d165-427f-a16d-48464854cdbc}");
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
                FMODUnity.RuntimeManager.PlayOneShot("{50a03cd1-218f-4718-8d95-b3106ef13e95}");
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
                FMODUnity.RuntimeManager.PlayOneShot("{75f00cf4-5a22-419f-9746-a82dd4e5e2d3}");
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
                FMODUnity.RuntimeManager.PlayOneShot("{279f5064-24d1-4d27-8593-0079dfef5ae1}");
                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[0].GetComponent<Health>().maxHealth = 15;
                enemies[0].transform.position = eSpawns[0].position;
                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[1].GetComponent<Health>().maxHealth = 15;
                enemies[1].transform.position = eSpawns[1].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[2].GetComponent<Health>().maxHealth = 8;
                enemies[2].transform.position = eSpawns[2].position;
                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[3].GetComponent<Health>().maxHealth = 8;
                enemies[3].transform.position = eSpawns[3].position;
                break;
            case 9:
                FMODUnity.RuntimeManager.PlayOneShot("{457f178f-2b39-4f81-ac7c-5004b757e3a6}");
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
                FMODUnity.RuntimeManager.PlayOneShot("{782a28ad-3ea5-402a-86f3-e57f4d462cca}");
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
            case 12:
                //debug round

                enemies.Add(Instantiate(unitPrefabs[0]));
                enemies[0].GetComponent<Health>().maxHealth = 5;
                enemies[0].transform.position = eSpawns[0].position;
             /* friends.Add(Instantiate(unitPrefabs[7]));
                friends[1].GetComponent<Health>().maxHealth = 4;
                friends[1].transform.position = fSpawns[1].position;
                enemies.Add(Instantiate(unitPrefabs[1]));
                enemies[1].GetComponent<Health>().maxHealth = 10;
                enemies[1].transform.position = eSpawns[4].position; */
                break;
        }
            
        }
}
