using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MircophoneInput : MonoBehaviour
{
    AudioSource aud;
    string deviceName;
    bool startFlag;
    // Start is called before the first frame update
    void Start()
    {
        aud = this.GetComponent<AudioSource>();
        
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
        deviceName = Microphone.devices[3];

        aud.clip = Microphone.Start(deviceName, true, 10, 48000);
        aud.loop = true;
        //aud.mute = true;
        startFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startFlag == false && Microphone.GetPosition(deviceName) > 0)
        {
            startFlag = true;
            Debug.Log("start:" + deviceName);
            aud.Play();
        }
    }
}
