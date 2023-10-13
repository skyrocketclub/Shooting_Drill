using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static bool toggleLight;
    public float onTime = 1.0f;
    public float offTime = 1.0f;
    private bool isLightOn = false;
    private List<Light> lightComponents = new List<Light>();
    // Start is called before the first frame update
    void Start()
    {
        Light[] lights = GetComponents<Light>();
        foreach(Light light in lights)
        {
            lightComponents.Add(light);
        }
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
            foreach(Light light in lightComponents)
            {
                if (isLightOn)
                {
                    light.enabled = false;
                    //yield return new WaitForSeconds(offTime);
                }
                else
                {
                    light.enabled = true;
                    //gameObject.SetActive(true);
                    //yield return new WaitForSeconds(onTime);
                }
            }
            yield return new WaitForSeconds(isLightOn?offTime:onTime);
            isLightOn = !isLightOn;
        }
    }

}
