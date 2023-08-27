using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Scrollbar sb;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI scoreFinal;
    [SerializeField] GameObject endScreen;
    float fallTime = 0;
    float dif;
    float initialDist;
    
    bool isFalling = true;
    // Start is called before the first frame update
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
            timeText.text = fallTime.ToString("F3");
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
    // Update is called once per frame
}
