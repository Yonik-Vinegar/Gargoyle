using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleScareSound : MonoBehaviour
{
    public AudioClip clipScare;
    public List<AudioClip> stopClip;
    public AudioSource sourceScare;
    public AudioSource sourceStop;
    public float cooldownTime = 1f;
    public float cooldownTicker = -1f;
    private bool playStop = false;

    void Update()
    {
        if (playStop && GargoyleScript.isSeen)
        {
            sourceStop.clip = stopClip[Random.Range(0, stopClip.Count)];
            sourceStop.Play();
            playStop = false;
        }
        if (!GargoyleScript.isSeen) { playStop = true; }
        if (!sourceScare.isPlaying) 
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
        }
    }
}
