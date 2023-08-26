using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float backgroundSpeed = 10f;
    float baseSpeed = 10f;
    int currentStage = 0;
    [SerializeField] PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = backgroundSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevel()
    {
        currentStage++;
        // Spawn new Enemies
        StartCoroutine(playerHealth.CanBeHit(0.7f));
        Debug.Log("Next stage: " + currentStage);
    }

    IEnumerator SlowDown()
    {
        backgroundSpeed = baseSpeed / 3f;
        yield return new WaitForSeconds(1f);
        baseSpeed += 5;
        backgroundSpeed = baseSpeed;
    }

    
}
