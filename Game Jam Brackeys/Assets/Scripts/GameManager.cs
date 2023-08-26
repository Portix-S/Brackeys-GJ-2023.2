using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float backgroundSpeed = 10f;
    float baseSpeed = 10f;
    int currentStage = 0;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] CinemachineVirtualCamera vc;
    public float fovChangeSpeed = 1f;
    [SerializeField] public GameObject[] lifeImages;
    [SerializeField] public GameObject[] particleSpawners;
    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = backgroundSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeParticleSpawner()
    {
        particleSpawners[currentStage].SetActive(false);
        Destroy(particleSpawners[currentStage]);
        if(currentStage < 3)
            particleSpawners[currentStage + 1].SetActive(true);
    }

    public void ChangeLevel()
    {
        currentStage++;
        // Spawn new Enemies
        StartCoroutine(playerHealth.CanBeHit(0.7f));
        StartCoroutine(ChangeFoV());
        Debug.Log("Next stage: " + currentStage);
    }

    IEnumerator ChangeFoV()
    {
        yield return new WaitForSeconds(1f);
        float size = vc.m_Lens.OrthographicSize;
        float maxSize = size + 2;
        vc.m_Lens.OrthographicSize += 3f;

        /*
        while (size < maxSize)
        {
            vc.m_Lens.OrthographicSize = Mathf.Lerp(size, maxSize, fovChangeSpeed * Time.deltaTime);
            size = vc.m_Lens.OrthographicSize;
        }
        //*/
        //vc.m_Lens.OrthographicSize = Mathf.Lerp(size, maxSize, fovChangeSpeed * Time.deltaTime);

    }


}
