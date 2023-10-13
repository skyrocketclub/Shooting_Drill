using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int totalTargets;
    public static int targetsShot = 0;
    public static bool timerIsRunning = false;

    public TextMeshProUGUI timer;
    private bool successful = false;
    private float elaspedTime;
    [SerializeField] private int timeInSeconds = 60;

    // Start is called before the first frame update
    void Start()
    {
        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;
        Debug.Log("There are " +  totalTargets + " targets");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            elaspedTime += Time.deltaTime;
            if(elaspedTime > 1.0f)
            {
                elaspedTime -= 1.0f;
                timeInSeconds--;
            }

            if(timeInSeconds == 12)
            {
                //Start playing the countdown... at 10 seconds
                AudioManager.countdown = true;
                LightManager.toggleLight = true;
            }

            if(timeInSeconds >= 0)
            {
                //There is still time
                timer.text = UpdateStopwatch();
            }
            else 
            {
                //Time Up!!!!!!!
                timer.text = "00 : 00";
                timerIsRunning = false;
                AudioManager.countdown = false;
                LightManager.toggleLight = false;
                if(targetsShot == totalTargets)
                {
                    successful = true;
                }
            }

            if (targetsShot == totalTargets)
            {
                //You finished the activity, shot all the targets
                timerIsRunning = false;
                AudioManager.countdown = false;
                LightManager.toggleLight = false;
                successful = true;
            }
        }
    }

    private string UpdateStopwatch()
    {
        int minutes = timeInSeconds / 60;
        int seconds = timeInSeconds % 60;
      //  int milliseconds = (int)((timeInSeconds - (minutes * 60 + seconds)) * 1000);
        string formattedTime = $"{minutes:00} : {seconds:00}";
        return formattedTime;
    }


}
