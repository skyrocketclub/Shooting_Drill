using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static bool toggleLight;
    public float onTime = 5.0f;
    public float offTime = 1.0f;
    private bool isLightOn = false;
    //private int lightNumber = transform.childCount;
    private GameObject[] lights;
    private Light lightComponent;

    // Start is called before the first frame update
    void Start()
    {
        int lightNumber = transform.childCount;
        lights = new GameObject[lightNumber];

        for(int i = 0; i < lightNumber; i++)
        {
            lights[i] = transform.GetChild(i).gameObject;
        }
        Debug.Log("There are " + lights.Length + " light gameobjects...");
        //foreach (Light light in lights)
        //{
        //    lightComponents.Add(light);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(toggleLight)
        {
            StartCoroutine(ToggleLights());
        }
    }

    private IEnumerator ToggleLights()
    {
        while (toggleLight)
        {
            foreach(GameObject light in lights)
            {
                if (isLightOn)
                {
                    light.SetActive(false);
                    //yield return new WaitForSeconds(offTime);
                }
                else
                {
                    light.SetActive(true);
                    lightComponent = light.GetComponent<Light>();
                    if(lightComponent != null )
                    {
                        lightComponent.intensity = 5.0f;
                    }

                    //gameObject.SetActive(true);
                    //yield return new WaitForSeconds(onTime);
                }
            }
            yield return new WaitForSeconds(isLightOn?offTime:onTime);
            isLightOn = !isLightOn;
        }
    }

}
