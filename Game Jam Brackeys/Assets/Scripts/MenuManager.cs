using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    float timeScale;
    bool isPaused;
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
}
