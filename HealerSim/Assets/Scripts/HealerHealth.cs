using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthDisplay;
    public Rigidbody rb;
    public bool deathLaunch;
    Camera cam;
    public Canvas UI;
    // public GameObject healthBackground;
    //  public GameObject camera

    void Start()
    {
        cam = Camera.main;
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
        if (health <= 0)
        {

            health = 0;
            rb.constraints = RigidbodyConstraints.None;
            deathLaunch = true;
            StartCoroutine(Die());
        }
       
        if (deathLaunch)
        {

            rb.AddForce(new Vector3(10, 0, 0));
            deathLaunch = false;
        }
    }
    IEnumerator Die()
    {
        //rb.constraints = RigidbodyConstraints.None;
        UI.gameObject.SetActive(false);
        cam.gameObject.transform.position = new Vector3(0, 8.3f, -15.75f);
        cam.gameObject.transform.rotation = Quaternion.Euler(65, 0, 0);
        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadScene("Death", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync("Main");
        //Destroy(gameObject);
    }
}
