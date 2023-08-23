using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float backgroundSpeed = 10f;
    int currentStage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevel()
    {
        currentStage++;
        // Spawn new Enemies
        StartCoroutine(SlowDown());
        Debug.Log("Next stage: " + currentStage);
    }

    IEnumerator SlowDown()
    {
        backgroundSpeed = 5f;
        yield return new WaitForSeconds(0.7f);
        backgroundSpeed = 10f;
    }
}
