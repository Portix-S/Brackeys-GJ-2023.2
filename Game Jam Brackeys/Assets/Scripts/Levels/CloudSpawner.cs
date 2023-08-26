using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField] GameObject powerup;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    [SerializeField]
    float minScale, maxScale, minSpeed, maxSpeed;

    [SerializeField]
    float depth, width, preWarmQuantity;

    Vector3 startPos;

    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Prewarm();
        Invoke("AttemptSpawn", spawnInterval);
    }

    void SpawnCloud(Vector3 startPos)
    {
        int randomIndex = Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex], parent);

        float startX = Random.Range(startPos.x - width, startPos.x + width);
        float startZ = Random.Range(startPos.z - depth, startPos.x + depth);

        cloud.transform.position = new Vector3(startX, startPos.y, startZ);

        float scale = Random.Range(minScale, maxScale);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = Random.Range(minSpeed, maxSpeed);
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.y);
        Destroy(cloud, 10f);

        int randomPowerUpChance = Random.Range(0, 100);
        if(randomPowerUpChance < 5)
        {
            GameObject powerUp = Instantiate(powerup, parent);
            startX = Random.Range(startPos.x - 13f, startPos.x + 13f);
            powerUp.transform.position = new Vector3(startX, startPos.y, startPos.z);
            Destroy(powerUp, 10f);
        }
    }

    void AttemptSpawn()
    {
        startPos = transform.position;
        //check some things.
        SpawnCloud(startPos);

        Invoke("AttemptSpawn", spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < preWarmQuantity; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 2);
            SpawnCloud(spawnPos);
        }
    }

    private void OnDestroy()
    {
        //Destroy(endPoint.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Despawner")
            Debug.Log("Achou");
    }
}
