using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{  
    public AudioSource audioSource;

    //CanvasOne
    public GameObject canvasOne;
    public AudioClip instructionClip;
    public GameObject volumeOnIcon;
    public GameObject volumeOffIcon;

    //CanvasTwo
    public GameObject canvasTwo;
    public AudioClip canvasTwoClip;
    public GameObject volumeIconActivated;
    public GameObject volumeIconDeactivated;

   // public bool instructionAudioIsPlaying = false;
    public bool instructionAudioNotPlaying = true;

    public AudioClip countdownClip;
    public static bool countdown = false;
    public static bool stopCountdown = false;
    public static bool stopAudio = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stopAudio)
        {
            stopAudio = false;
            audioSource.Stop();
        }
        if (countdown)
        {
            countdown = false;
            audioSource.Stop();
            audioSource.clip = countdownClip;
            audioSource.Play();
        }
        if (stopCountdown)
        {
            audioSource.Stop();
        }
    }

    public void PlayInstruction(AudioClip audioClip, GameObject volumeOffButton, GameObject volumeOnButton)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        volumeOffButton.SetActive(false);
        volumeOnButton.SetActive(true);
        instructionAudioNotPlaying = false;
    }

    public void StopInstruction(GameObject volumeOffButton, GameObject volumeOnButton)
    {
        audioSource.Stop();
        volumeOffButton.SetActive(true);
        volumeOnButton.SetActive(false);
        instructionAudioNotPlaying = true;
    }

    public void ToggleAudio()
    {
        if(instructionAudioNotPlaying)
        {
            if(canvasOne.activeSelf && !canvasTwo.activeSelf)
            {
                PlayInstruction(instructionClip,volumeOffIcon,volumeOnIcon);
            }else if(!canvasOne.activeSelf && canvasTwo.activeSelf)
            {
                PlayInstruction(canvasTwoClip,volumeIconDeactivated, volumeIconActivated);
            }
           
        }else
        {
            if(canvasOne.activeSelf && !canvasTwo.activeSelf)
            {
                StopInstruction(volumeOffIcon,volumeOnIcon);
            }else if(!canvasOne.activeSelf && canvasTwo.activeSelf)
            {
                StopInstruction(volumeIconDeactivated,volumeIconActivated);
            }
            
        }
    }
}
