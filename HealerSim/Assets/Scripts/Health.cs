using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthDisplay;
  
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float healthRatio;
        healthRatio = health / maxHealth;
        healthDisplay.transform.localScale = new Vector3 (healthRatio,1,1);
        if(health ==  maxHealth)
        {
            healthDisplay.GetComponentInChildren<Renderer>().material.color = Color.green;
        }
        else if (health < maxHealth && health > maxHealth / 3)
        {
            healthDisplay.GetComponentInChildren<Renderer>().material.color = Color.yellow;
        }
        else if (health <= maxHealth /3)
        {
            healthDisplay.GetComponentInChildren<Renderer>().material.color = Color.red;
        }
        
    }
}
