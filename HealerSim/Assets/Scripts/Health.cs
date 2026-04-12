using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthDisplay;
    // public GameObject healthBackground;
    //  public GameObject camera
    public bool dying;
    void Start()
    {
        health = maxHealth;
        dying = false;
    }

    // Update is called once per frame
    void Update()
    {
        //healthDisplay.transform.LookAt(Camera.main.transform);
        //healthBackground.transform.LookAt(Camera.main.transform);
        float healthRatio;
        healthRatio = health / maxHealth;
        if(healthDisplay != null)
        {
            healthDisplay.transform.localScale = new Vector3(healthRatio, 1, 1);
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            if (health == maxHealth)
            {
                healthDisplay.GetComponentInChildren<Renderer>().material.color = Color.green;
            }
            else if (health < maxHealth && health > maxHealth / 3)
            {
                healthDisplay.GetComponentInChildren<Renderer>().material.color = Color.yellow;
            }
            else if (health <= maxHealth / 3)
            {
                healthDisplay.GetComponentInChildren<Renderer>().material.color = Color.red;
            }
            
            if (health <= 0)
            {
                dying = true;
                StartCoroutine(Die());
            }
            if(dying == true)
            {
                health = 0;
            }
        }
        
      
    }
    IEnumerator Die()
    {
        if (gameObject.tag == "Tank")
        {
            FMODUnity.RuntimeManager.PlayOneShot("{ 599f3e81 - 1807 - 4225 - 8d63 - 2517f11960c5}", gameObject.transform.position);          
        }
        else if (gameObject.tag == "Melee")
        {
            FMODUnity.RuntimeManager.PlayOneShot("{af1625d1-4a56-486c-928f-98f6ed27024f}", gameObject.transform.position);
        }
        else if (gameObject.tag == "Ranger")
        {
            FMODUnity.RuntimeManager.PlayOneShot("{b5440849-3dd6-4946-b026-52143b436c80}", gameObject.transform.position);
        }
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
