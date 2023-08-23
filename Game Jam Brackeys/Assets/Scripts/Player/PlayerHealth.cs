using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int life = 2;
    public bool canTakeDmg;
    [SerializeField] float hitCd = 1;
    [SerializeField] GameObject[] lifeSprites;

    public float transitionDuration = 2.0f; // Duration of the transparency transition
    [SerializeField] Material material;
    private Color originalColor;
    private Color transparentColor;

    private float currentTime = 0.0f;
    private bool isTransitioning = false;

    private bool slowMotionActive = false;
    public void Start()
    {

        originalColor = Color.red;
        material.color = Color.red;
        

    }

    private void FixedUpdate()
    {
        SlowMotion();
    }
    private void Update()
    {
        if (isTransitioning && !canTakeDmg)
        {
            Debug.Log("HIT");
            currentTime += Time.deltaTime;

            // Calculate the current transparency value based on the transition progress
            float t = Mathf.Clamp01(currentTime / transitionDuration);
            Color lerpedColor = Color.Lerp(Color.black, Color.white, t);

            // Apply the new color to the material
            material.color = lerpedColor;

        }
        else
        {
            material.color = Color.red;
        }
    }

    public void StartTransition()
    {
        material.color = Color.black;
        currentTime = 0.0f;
        isTransitioning = true;
    }
    public void TakeHit(int dmg)
    {
        
        StartTransition();
        canTakeDmg = false;
        lifeSprites[life - 1].SetActive(false);
        StartCoroutine(CanBeHit(hitCd));
        life -= dmg;
        
        if(life <= 0)
        {
            Destroy(gameObject);
        }
   
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator CanBeHit(float cd)
    {
        slowMotionActive = true;
        canTakeDmg = false;
        yield return new WaitForSeconds(cd);
        canTakeDmg = true;
        
        material.color = Color.red;
        slowMotionActive = false;
    }

    private void SlowMotion()
    {
        if (slowMotionActive)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale; // Adjust this value as needed
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
