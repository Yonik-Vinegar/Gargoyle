using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioClip currentClip;
    public AudioSource source;
    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float waitTimeCountdown = -1f;
    public GameObject player;
 
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
 
    void Update()
    {
        if (!source.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                currentClip = audioClips[Random.Range(0, audioClips.Count)];
                source.clip = currentClip;
                source.Play();
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
                transform.position = player.transform.position + new Vector3(Random.Range(-10,10),0,Random.Range(-10,10));
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
}
