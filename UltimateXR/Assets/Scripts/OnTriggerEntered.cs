using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEntered : MonoBehaviour
{

    public ParticleSystem particleSystem;
    public GameObject target;
    public GameObject light;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DetectAndActOnChild("ShotgunImpactDecal(Clone)");
        DetectAndActOnChild("MachinegunImpactDecal(Clone)");
        DetectAndActOnChild("GunImpactDecal(Clone)");
    }

    private void DetectAndActOnChild(string childName)
    {
        Transform child = transform.Find(childName);
        if (child != null)
        {
            light.SetActive(true);
            particleSystem.Play();
            audioSource.Play();
            StartCoroutine(Destroy());
        }
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(target.gameObject);
    }
}
