using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMan : MonoBehaviour
{
    public Button pauseButt;
    public static bool paused;

    public GameObject pauseScreen;

    public Button resumeButt;
    public Button restartButt;
    public Button quitButt;


    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        pauseButt.onClick.AddListener(PauseClick);
        resumeButt.onClick.AddListener(PauseClick);
        restartButt.onClick.AddListener(RestartClick);
        quitButt.onClick.AddListener(QuitClick);
    }

    // Update is called once per frame
    void Update()
    {
      // pauseButt.onClick.AddListener(PauseClick);

       
        if (paused)
        {
            Time.timeScale = 0.0f;
            pauseButt.gameObject.SetActive(false);
            
        }
        else if (!paused)
        {
            Time.timeScale = 1.0f;
            pauseButt.gameObject.SetActive(true);
           
        }

       

    }
    void PauseClick()
    {
        paused = !paused;
        pauseScreen.SetActive(paused);
        
    }
    void RestartClick()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    void QuitClick()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync("Main");
    }

}
