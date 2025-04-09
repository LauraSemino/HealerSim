using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMan : MonoBehaviour
{
    public Button StartButt;
    public Button QuitButt;
    // Start is called before the first frame update
    void Start()
    {
        StartButt.onClick.AddListener(StartClick);
        QuitButt.onClick.AddListener(QuitClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void StartClick()
    {
        //Debug.Log("start");
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync("Start");
    }

    void QuitClick()
    {
        Application.Quit();
    }
    
}
