using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public const string VOLUME_LEVEL_KEY = "VolumeLevel";
    public const float DEFAULT_VOLUME = 0.5f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        float volume = PlayerPrefs.GetFloat(VOLUME_LEVEL_KEY, DEFAULT_VOLUME);
        audioSource.volume = volume;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AdjustVolume(float level){
        audioSource.volume = level;
        PlayerPrefs.SetFloat("VolumeLevel", level);
    }
}
