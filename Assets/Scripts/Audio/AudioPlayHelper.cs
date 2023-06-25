using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
{
    public KeyCode KeyCode = KeyCode.P;
    public AudioSource audioSource;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode))
        {
            Play();
        }
    }

    public void Play()
    {
        audioSource.Play();
    }
}
