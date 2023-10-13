using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvasOne;
    public GameObject canvasTwo;
    public GameObject stopWatch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCanvasOneButtonClicked()
    {
        canvasOne.SetActive(false);
        canvasTwo.SetActive(true);
    }

    public void OnCanvasTwoButtonClicked()
    {
        canvasTwo.SetActive(false);
        stopWatch.SetActive(true);
        GameManager.timerIsRunning = true;
    }

}
