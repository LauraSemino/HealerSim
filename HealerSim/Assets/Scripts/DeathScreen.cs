using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Button RestartButt;
    public Button QuitButt;
    // public Scene GameScene;
    // Start is called before the first frame update
    void Start()
    {
        RestartButt.onClick.AddListener(RestartClick);
        QuitButt.onClick.AddListener(QuitClick);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void RestartClick()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync("Death");
    }
    void QuitClick()
    {
        Application.Quit();
    }
}
