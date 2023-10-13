using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static bool toggleLight;
    public float onTime = 1.0f;
    public float offTime = 1.0f;
    private bool isLightOn = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(toggleLight)
        {
            StartCoroutine(ToggleLight());
        }
    }

    private IEnumerator ToggleLight()
    {
        while (toggleLight)
        {
            if (isLightOn)
            {
                gameObject.SetActive(false);
                yield return new WaitForSeconds(offTime);
            }
            else
            {
                gameObject.SetActive(true);
                yield return new WaitForSeconds(onTime);
            }
            isLightOn = !isLightOn;
        }
    }

}
