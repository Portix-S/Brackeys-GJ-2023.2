using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    float timeScale;
    bool isPaused;
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            StopTime();
        }
    }

    public void StopTime()
    {
        isPaused = !isPaused;
        menu.SetActive(isPaused);
        if (isPaused)
        {
            timeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = timeScale;
        }
    }

    public void RestartScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void GoToScene(string x)
    {
        
        SceneManager.LoadScene(x);
        
    }
    public void Exit()
    {
        
        Application.Quit();
        
    }
}
