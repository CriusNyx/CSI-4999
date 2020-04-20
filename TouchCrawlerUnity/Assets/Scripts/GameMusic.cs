using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameMusic : MonoBehaviour
{

    public AudioClip song;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        PlaySound();
        InvokeRepeating("UpdateSound", 0, 1.0f);
    }

    void UpdateSound()
    {
        source.volume = UserSettings.musicVolume;
    }

    public void PlaySound()
    {
        if (source != null)
        {
            var rand = new System.Random();
            source.clip = song;
            source.Play();
        }

    }
}
