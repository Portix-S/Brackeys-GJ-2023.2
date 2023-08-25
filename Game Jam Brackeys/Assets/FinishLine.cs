using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Scrollbar sb;
    float dif;
    float initialDist;
    // Start is called before the first frame update
    void Start()
    {
        initialDist = playerTransform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        dif = playerTransform.position.y - transform.position.y;
        sb.value = dif / initialDist;
    }
}
