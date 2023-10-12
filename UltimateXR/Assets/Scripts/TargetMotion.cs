using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMotion : MonoBehaviour
{
    public float speed = 0.1f;
    public float switchDelay = 2.0f;
    private float timer;
    private bool movePositive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Oscillate();
    }

    void Oscillate()
    {
        float moveDirection = movePositive ? 1f : -1f;
        transform.Translate(0f, moveDirection * speed * Time.deltaTime, 0f);
        timer += Time.deltaTime;
        if(timer >= switchDelay )
        {
            timer = 0f;
            movePositive = !movePositive;
        }
    }
}
