using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthDisplay;
    // public GameObject healthBackground;
    //  public GameObject camera

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //healthDisplay.transform.LookAt(Camera.main.transform);
        //healthBackground.transform.LookAt(Camera.main.transform);
        float healthRatio;
        healthRatio = health / maxHealth;
        healthDisplay.transform.localScale = new Vector3(healthRatio, 1, 1);

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health == maxHealth)
        {
            healthDisplay.GetComponent<Image>().color = Color.green;
        }
        else if (health < maxHealth && health > maxHealth / 3)
        {
            healthDisplay.GetComponent<Image>().color = Color.yellow;
        }
        else if (health <= maxHealth / 3)
        {
            healthDisplay.GetComponent<Image>().color = Color.red;
        }
    }
}
