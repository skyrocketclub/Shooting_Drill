using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject canvasOne;
    public GameObject canvasTwo;
    public GameObject stopWatch;
    public GameObject successCanvas;
    public GameObject failureCanvas;
    public GameObject hallOfFame;

    public static bool showSuccessCanvas = false;
    public static bool showFailureCanvas = false;

    public TMP_InputField nameInputField; //where user enters the name...

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

    public void OnViewHallOfFameButtonClicked()
    {
        //if (successCanvas.activeSelf)
        //{
        //    successCanvas.SetActive(false);
        //    hallOfFame.SetActive(true);
        //    GameManager.viewHallOfFame = true;
        //}else
        if (failureCanvas.activeSelf)
        {
            failureCanvas.SetActive(false);
            hallOfFame.SetActive(true);
            GameManager.viewHallOfFame = true;
        }
    }

    public void OnEnterNameIntoHallOfFameClicked()
    {
        //Update hall of fame list
        //equate the inputField text 
        GameManager.nameToAdd = nameInputField.text;
        GameManager.addName = true;
        successCanvas.SetActive(false);
        hallOfFame.SetActive(true);

    }

}
