using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public int totalTargets;
    public static int targetsShot = 0;
    public static bool timerIsRunning = false;

    public TextMeshProUGUI timer;
    private bool successful = false;
    private float elaspedTime;
    [SerializeField] private int timeInSeconds = 60;

    public List<string> names;
    public static string nameToAdd = ""; //takes the name entered on the success canvas
    public static bool addName = false;
    public static bool viewHallOfFame = false;
    public TextMeshProUGUI namesText;

    // Start is called before the first frame update
    void Start()
    {
        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;
        Debug.Log("There are " +  totalTargets + " targets");
        namesText.text = "";
        names = LoadStrings();
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

            if(timeInSeconds == 12 && successful == false)
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
                    UIManager.showSuccessCanvas = true;
                }
                else
                {
                    UIManager.showFailureCanvas = true;
                }
            }

            if (targetsShot == totalTargets)
            {
                //You finished the activity, shot all the targets
                timerIsRunning = false;
                AudioManager.countdown = false;
                LightManager.toggleLight = false;
                successful = true;
                UIManager.showSuccessCanvas = true;
            }
        }

        if (addName)
        {
            addName = false;
            UpdateHallOfFame();
            names = LoadStrings(); // get the updated list from the json
            DisplayHallOfFame();
        }
        if (viewHallOfFame)
        {
            viewHallOfFame = false;
            DisplayHallOfFame();
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

    public void RestartScene()
    {
        targetsShot = 0;
        timeInSeconds = 60;
        timerIsRunning = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        if(EditorApplication.isPlaying){
            EditorApplication.isPlaying = false;
        }
#else
        Application.Quit();
#endif
    }







    // Data retention section...

    public void DisplayHallOfFame()
    {
        names = LoadStrings();// Load data from the JSON...
        //format the array and display apprioprately on canvas
        for(int i = 0; i < names.Count; i++)
        {
            namesText.text += names[i];
            namesText.text += "\n";
        }
    }

    public void UpdateHallOfFame()
    {
        //Add the name to the array
        names.Add(nameToAdd);
        SaveNames(names);
        //Add the new text you are given into the hall of fame...
    }


    [System.Serializable] //enables it to be converted to JSON
    class SaveData
    {
        public List<string> names;
        // public string[] names;
    }

    public void SaveNames(List<string> namesToSave)
    {
        SaveData data = new SaveData();
        data.names = namesToSave;
        string json = JsonUtility.ToJson(data); //trnasforming the instance to JSON
        string path = Application.persistentDataPath + "/savefile.json";

        try
        {
            File.WriteAllText(path, json);
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving strings: " + e.Message);
        }
    }

    //public string[] LoadStrings()
    public List<string> LoadStrings()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            try
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                return data.names;
            }
            catch (Exception e)
            {
                Debug.LogError("Error loading strings: " + e.Message);
            }
        }
        else
        {
            Debug.LogWarning("Save file does not exist.");
            UpdateHallOfFame();
        }
        return new List<string>();
    }
}
