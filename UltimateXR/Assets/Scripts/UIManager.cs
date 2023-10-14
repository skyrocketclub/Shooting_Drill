using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvasOne;
    public GameObject canvasTwo;
    public GameObject stopWatch;
    public GameObject successCanvas;
    public GameObject failureCanvas;

    public static bool showSuccessCanvas = false;
    public static bool showFailureCanvas = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showSuccessCanvas)
        {
            showSuccessCanvas = false;
            stopWatch.SetActive(false);
            successCanvas.SetActive(true);
        }else if (showFailureCanvas)
        {
            showFailureCanvas = false;
            stopWatch.SetActive(false);
            failureCanvas.SetActive(true);
        }
    }

    public void OnCanvasOneButtonClicked()
    {
        canvasOne.SetActive(false);
        canvasTwo.SetActive(true);
        AudioManager.stopAudio = true;
    }

    public void OnCanvasTwoButtonClicked()
    {
        canvasTwo.SetActive(false);
        stopWatch.SetActive(true);
        GameManager.timerIsRunning = true;
        AudioManager.stopAudio = true;
    }

}
