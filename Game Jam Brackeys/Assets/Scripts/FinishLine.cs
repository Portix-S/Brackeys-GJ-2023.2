using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Scrollbar sb;
    [SerializeField] GameObject endScreen;
    [SerializeField] TextMeshProUGUI scoreFinal;
    [SerializeField] TextMeshProUGUI timeText;
    float fallTime = 0;
    float dif;
    float initialDist;
    bool isFalling = true;

    void Start()
    {
        initialDist = playerTransform.position.y - transform.position.y;
    }

    void Update()
    {
        Scroll();
        CalculateTime();
    }

    public void Scroll()
    {
        dif = playerTransform.position.y - transform.position.y;
        sb.value = dif / initialDist;
    }

    public void CalculateTime()
    {
        if (isFalling)
        {
            fallTime += Time.deltaTime;
            timeText.text = fallTime.ToString();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isFalling = false;
            timeText.transform.parent.gameObject.SetActive(false);
            scoreFinal.text = timeText.text;
            endScreen.SetActive(true);
        }
        
        
    }
}
