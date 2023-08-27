using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] PlayerHealth health;
    [SerializeField] GameObject youLose;
    float timeScale;
    public bool isPaused;
    private void Start()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.01f;
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
        Debug.Log(isPaused);
        if (isPaused)
        {
            timeScale = Time.timeScale;
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0f;
        }
        else
        {
            if(health.life > 0)
            {
                Time.timeScale = timeScale;
                Time.fixedDeltaTime = 0.02f;
            }
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
