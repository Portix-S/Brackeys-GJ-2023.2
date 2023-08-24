using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsBelow : MonoBehaviour
{
    [SerializeField] GameObject[] objs;
    //Transform playerTransf;
    [SerializeField] float spawnCd = 1;
    float secondsCounter;
    int escolha;
    // Start is called before the first frame update
    void Start()
    {
        //playerTransf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        secondsCounter -= Time.deltaTime;
        if(secondsCounter < 0)
        {
            
            escolha = Random.Range(0, 4);
            secondsCounter = spawnCd;
            if(escolha == 0)
            {
                GameObject obj = Instantiate(objs[Random.Range(0, objs.Length - 1)], new Vector3(transform.position.x, transform.position.y - 10, transform.position.z), transform.rotation);
                obj.GetComponent<Rigidbody>().AddForce(Vector3.up * 100, ForceMode.Impulse);
            }
            else if(escolha == 2)
            {
                GameObject obj = Instantiate(objs[Random.Range(0, objs.Length - 1)], new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.rotation);
                obj.GetComponent<Rigidbody>().AddForce(Vector3.down * 100, ForceMode.Impulse);
            }
            else if (escolha == 3)
            {
                GameObject obj = Instantiate(objs[Random.Range(0, objs.Length - 1)], new Vector3(transform.position.x - 10, transform.position.y, transform.position.z), transform.rotation);
                obj.GetComponent<Rigidbody>().AddForce(Vector3.right * 100, ForceMode.Impulse);
            }
            else if (escolha == 4)
            {
                GameObject obj = Instantiate(objs[Random.Range(0, objs.Length - 1)], new Vector3(transform.position.x + 10, transform.position.y, transform.position.z), transform.rotation);
                obj.GetComponent<Rigidbody>().AddForce(Vector3.left * 100, ForceMode.Impulse);
            }
            
        }
    }
}
