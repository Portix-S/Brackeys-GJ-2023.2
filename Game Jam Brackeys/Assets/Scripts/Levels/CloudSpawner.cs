using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;


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
        GameObject cloud = Instantiate(clouds[randomIndex], gameObject.transform.parent);

        float startX = Random.Range(startPos.x - 13f, startPos.x + 13f);
        float startZ = Random.Range(startPos.z - 4f, startPos.x + 4f);

        cloud.transform.position = new Vector3(startX, startPos.y, startZ);

        float scale = Random.Range(1f, 3f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = Random.Range(2f, 5f);
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.y);


    }

    void AttemptSpawn()
    {
        //check some things.
        SpawnCloud(startPos);

        Invoke("AttemptSpawn", spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 2);
            SpawnCloud(spawnPos);
        }
    }

    private void OnDestroy()
    {
        Destroy(endPoint.gameObject);
    }
}
