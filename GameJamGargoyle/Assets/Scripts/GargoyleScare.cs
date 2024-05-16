using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleScareSound : MonoBehaviour
{
    public AudioClip clipScare;
    public List<AudioClip> stopClip;
    public AudioSource sourceScare;
    public AudioSource sourceStop;
    public AudioSource sourceStatic1;
    public AudioSource sourceStatic2;
    public float cooldownTime = 1f;
    public float cooldownTicker = -1f;
    private bool playStop = false;

    void Update()
    {
        if (/*!sourceStop.isPlaying && */playStop && GargoyleScript.isSeen)
        {
            sourceStop.clip = stopClip[Random.Range(0, stopClip.Count)];
            sourceStop.Play();
            playStop = false;
            sourceStatic1.Play();
            sourceStatic2.Play();
        }
        if (!GargoyleScript.isSeen) 
        { 
            playStop = true; 
            sourceStatic1.Stop();
            sourceStatic2.Stop();
        }
        /* if (!sourceScare.isPlaying) 
        {
            if (cooldownTicker < 0f && GargoyleScript.isSeen)
            {
                sourceScare.volume = 1f;
                sourceScare.clip = clipScare;
                sourceScare.Play();
            }
            else if (!GargoyleScript.isSeen)
            {
                cooldownTicker -= Time.deltaTime;
            }
            if (sourceScare.volume > 0f && !GargoyleScript.isSeen)
            {
                sourceScare.volume = sourceScare.volume - Time.deltaTime;
            }
            if (sourceScare.volume < 0f) { sourceScare.Stop(); }
        } */
    }
}
